using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Weaving;
using NCop.Core.Extensions;
using System.Reflection.Emit;
using NCop.Aspects.Engine;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class AspectArgsMapperWeaver : IWeaver, IAspectArgsMapper
    {
        internal Dictionary<int, MethodInfo> funcAspectArgMapperMethodsDictionary = null;
        internal Dictionary<int, MethodInfo> actionAspectArgMapperMethodsDictionary = null;

        public void Weave() {
            Type weavedFuncType = null;
            Type weavedActionType = null;
            BindingFlags weavedMethodsFlags = BindingFlags.NonPublic | BindingFlags.Static;
            var typeAttrs = TypeAttributes.NotPublic | TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;
            var funcAspectArgMapperTypeBuilder = typeof(object).DefineType("FunctionArgsMapper".ToUniqueName(), attributes: typeAttrs);
            var actionAspectArgMapperTypeBuilder = typeof(object).DefineType("ActionArgsMapper".ToUniqueName(), attributes: typeAttrs);
            var methodAttr = MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static | MethodAttributes.HideBySig;

            Enumerable.Range(1, 8).ForEach(i => {
                Type funcArgumentType = null;
                Type actionArgumentType = null;
                ILGenerator funcILGenerator = null;
                ILGenerator actionILGenerator = null;
                PropertyInfo returnValueProperty = null;
                Type genericTypeFuncArgumentType = null;
                Type genericTypeActionArgumentType = null;
                GenericTypeParameterBuilder[] genericParameters = null;
                var funcArgsMethodBuilder = funcAspectArgMapperTypeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);
                var actionArgsMethodBuilder = actionAspectArgMapperTypeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);
                var genericArgumentsArray = Enumerable.Range(1, i)
                                                      .Select(j => "Arg{0}".Fmt(j))
                                                      .ToList();

                genericParameters = actionArgsMethodBuilder.DefineGenericParameters(genericArgumentsArray.ToArray());
                genericTypeActionArgumentType = ResolveIActionArgsType(i);
                actionArgumentType = genericTypeActionArgumentType.MakeGenericType(genericParameters);
                actionArgsMethodBuilder.SetParameters(new Type[] { actionArgumentType, actionArgumentType });
                genericArgumentsArray.Add("TResult");
                genericParameters = funcArgsMethodBuilder.DefineGenericParameters(genericArgumentsArray.ToArray());
                genericTypeFuncArgumentType = ResolveIFunctionArgsType(i);
                funcArgumentType = genericTypeFuncArgumentType.MakeGenericType(genericParameters);
                funcArgsMethodBuilder.SetParameters(new Type[] { funcArgumentType, funcArgumentType });
                funcILGenerator = funcArgsMethodBuilder.GetILGenerator();
                actionILGenerator = actionArgsMethodBuilder.GetILGenerator();

                Enumerable.Range(1, i).ForEach(j => {
                    var funcPropertyInfo = genericTypeFuncArgumentType.GetProperty("Arg{0}".Fmt(j));
                    var actionPropertyInfo = genericTypeActionArgumentType.GetProperty("Arg{0}".Fmt(j));

                    funcILGenerator.Emit(OpCodes.Ldarg_1);
                    actionILGenerator.Emit(OpCodes.Ldarg_1);
                    funcILGenerator.Emit(OpCodes.Ldarg_0);
                    actionILGenerator.Emit(OpCodes.Ldarg_0);

                    funcILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(funcArgumentType, funcPropertyInfo.GetGetMethod()));
                    actionILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(actionArgumentType, actionPropertyInfo.GetGetMethod()));
                    funcILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(funcArgumentType, funcPropertyInfo.GetSetMethod()));
                    actionILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(actionArgumentType, actionPropertyInfo.GetSetMethod()));
                });

                funcILGenerator.Emit(OpCodes.Ldarg_1);
                funcILGenerator.Emit(OpCodes.Ldarg_0);
                returnValueProperty = genericTypeFuncArgumentType.GetProperty("ReturnValue");
                funcILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(funcArgumentType, returnValueProperty.GetGetMethod()));
                funcILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(funcArgumentType, returnValueProperty.GetSetMethod()));

                funcILGenerator.Emit(OpCodes.Ret);
                actionILGenerator.Emit(OpCodes.Ret);
            });

            weavedFuncType = funcAspectArgMapperTypeBuilder.CreateType();
            weavedActionType = actionAspectArgMapperTypeBuilder.CreateType();

            funcAspectArgMapperMethodsDictionary = weavedFuncType.GetMethods(weavedMethodsFlags)
                                                                 .ToDictionary(method => method.GetGenericArguments().Length);

            actionAspectArgMapperMethodsDictionary = weavedActionType.GetMethods(weavedMethodsFlags)
                                                                     .ToDictionary(method => method.GetGenericArguments().Length);
        }

        private Type ResolveIFunctionArgsType(int count) {
            switch (count) {
                case 0:
                    return typeof(IFunctionArgs<>);
                case 1:
                    return typeof(IFunctionArgs<,>);
                case 2:
                    return typeof(IFunctionArgs<,,>);
                case 3:
                    return typeof(IFunctionArgs<,,,>);
                case 4:
                    return typeof(IFunctionArgs<,,,,>);
                case 5:
                    return typeof(IFunctionArgs<,,,,,>);
                case 6:
                    return typeof(IFunctionArgs<,,,,,,>);
                case 7:
                    return typeof(IFunctionArgs<,,,,,,,>);
                case 8:
                    return typeof(IFunctionArgs<,,,,,,,,>);
                default:
                    return null;
            }
        }

        private Type ResolveIActionArgsType(int count) {
            switch (count) {
                case 0:
                    return typeof(IActionArgs);
                case 1:
                    return typeof(IActionArgs<>);
                case 2:
                    return typeof(IActionArgs<,>);
                case 3:
                    return typeof(IActionArgs<,,>);
                case 4:
                    return typeof(IActionArgs<,,,>);
                case 5:
                    return typeof(IActionArgs<,,,,>);
                case 6:
                    return typeof(IActionArgs<,,,,,>);
                case 7:
                    return typeof(IActionArgs<,,,,,,>);
                case 8:
                    return typeof(IActionArgs<,,,,,,,>);
                default:
                    return null;
            }
        }

        public MethodInfo GetMappingArgsAction(int argumentCount) {
            return funcAspectArgMapperMethodsDictionary[argumentCount];
        }

        public MethodInfo GetMappingArgsFunction(int argumentCount) {
            return funcAspectArgMapperMethodsDictionary[argumentCount];
        }
    }
}



