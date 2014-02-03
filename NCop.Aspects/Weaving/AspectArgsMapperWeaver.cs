using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

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

            Enumerable.Range(0, 8).ForEach(i => {
                if (i > 0) {
                    BuildMethod(actionAspectArgMapperTypeBuilder, i, ResolveIActionArgsType, false);
                }

                BuildMethod(funcAspectArgMapperTypeBuilder, i, ResolveIFunctionArgsType, true);
            });

            weavedFuncType = funcAspectArgMapperTypeBuilder.CreateType();
            weavedActionType = actionAspectArgMapperTypeBuilder.CreateType();

            funcAspectArgMapperMethodsDictionary = weavedFuncType.GetMethods(weavedMethodsFlags)
                                                                 .ToDictionary(method => method.GetGenericArguments().Length);

            actionAspectArgMapperMethodsDictionary = weavedActionType.GetMethods(weavedMethodsFlags)
                                                                     .ToDictionary(method => method.GetGenericArguments().Length);
        }

        private void BuildMethod(TypeBuilder typeBuilder, int numberOfArgs, Func<int, Type> resolveArgsFn, bool hasReturnType) {
            Type argumentType = null;
            ILGenerator ilGenerator = null;
            PropertyInfo methodProperty = null;
            Type genericTypeArgumentType = null;
            PropertyInfo returnValueProperty = null;
            GenericTypeParameterBuilder[] genericParameters = null;
            var methodAttr = MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static | MethodAttributes.HideBySig;
            var methodBuilder = typeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);
            var genericArgumentsArray = Enumerable.Range(1, numberOfArgs)
                                                  .Select(j => "Arg{0}".Fmt(j))
                                                  .ToList();

            if (hasReturnType) {
                genericArgumentsArray.Add("TResult");
            }

            genericParameters = methodBuilder.DefineGenericParameters(genericArgumentsArray.ToArray());
            genericTypeArgumentType = resolveArgsFn(numberOfArgs);
            argumentType = genericTypeArgumentType.MakeGenericType(genericParameters);
            methodBuilder.SetParameters(new Type[] { argumentType, argumentType });
            ilGenerator = methodBuilder.GetILGenerator();
            methodProperty = genericTypeArgumentType.GetProperty("Method");

            Enumerable.Range(1, numberOfArgs).ForEach(j => {
                var propertyInfo = genericTypeArgumentType.GetProperty("Arg{0}".Fmt(j));

                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, propertyInfo.GetGetMethod()));
                ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, propertyInfo.GetSetMethod()));
            });

            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, methodProperty.GetGetMethod()));
            ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, methodProperty.GetSetMethod()));

            if (hasReturnType) {
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Ldarg_0);
                returnValueProperty = genericTypeArgumentType.GetProperty("ReturnValue");
                ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, returnValueProperty.GetGetMethod()));
                ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, returnValueProperty.GetSetMethod()));
            }

            ilGenerator.Emit(OpCodes.Ret);
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
            return actionAspectArgMapperMethodsDictionary[argumentCount];
        }

        public MethodInfo GetMappingArgsFunction(int argumentCount) {
            return funcAspectArgMapperMethodsDictionary[argumentCount];
        }
    }
}



