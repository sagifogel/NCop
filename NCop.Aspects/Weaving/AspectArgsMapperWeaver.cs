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
    public class AspectArgsMapperWeaver : ITypeWeaver, IAspectArgsMapper
    {
        private Dictionary<int, MethodInfo> funcAspectArgMapperMethodsDictionary = null;
        private Dictionary<int, MethodInfo> actionAspectArgMapperMethodsDictionary = null;
        private readonly BindingFlags weavedMethodsFlags = BindingFlags.NonPublic | BindingFlags.Static;
        private Dictionary<Tuple<Type, Type>, MethodInfo> propertyAspectArgMapperMethodsDictionary = null;
        private readonly TypeAttributes typeAttrs = TypeAttributes.NotPublic | TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;
        private readonly MethodAttributes methodAttr = MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static | MethodAttributes.HideBySig;

        public void Weave() {
            Type weavedFuncType = null;
            Type weavedActionType = null;
            var typefObject = typeof(object);
            var funcAspectArgMapperTypeBuilder = typefObject.DefineType("FunctionArgsMapper".ToUniqueName(), attributes: typeAttrs);
            var actionAspectArgMapperTypeBuilder = typefObject.DefineType("ActionArgsMapper".ToUniqueName(), attributes: typeAttrs);

            Enumerable.Range(0, 9).ForEach(i => {
                if (i == 0) {
                    BuildNonGenericTypeMethod(actionAspectArgMapperTypeBuilder, i, ResolveIActionArgsType);
                }
                else {
                    BuildMethod(actionAspectArgMapperTypeBuilder, i, ResolveIActionArgsType, false);
                }

                BuildMethod(funcAspectArgMapperTypeBuilder, i, ResolveIFunctionArgsType, true);
            });

            WeavePropertyMappingMethods();
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
            GenericTypeParameterBuilder[] genericParameters = null;
            var methodBuilder = typeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);
            var genericArgumentsArray = Enumerable.Range(1, numberOfArgs)
                                                  .ToList(j => "Arg{0}".Fmt(j));

            if (hasReturnType) {
                genericArgumentsArray.Add("TResult");
            }

            genericParameters = methodBuilder.DefineGenericParameters(genericArgumentsArray.ToArray());
            genericTypeArgumentType = resolveArgsFn(numberOfArgs);
            argumentType = genericTypeArgumentType.MakeGenericType(genericParameters);
            methodBuilder.SetParameters(new[] { argumentType, argumentType });
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
                var returnValueProperty = genericTypeArgumentType.GetProperty("ReturnValue");

                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, returnValueProperty.GetGetMethod()));
                ilGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(argumentType, returnValueProperty.GetSetMethod()));
            }

            ilGenerator.Emit(OpCodes.Ret);
        }

        private void WeavePropertyMappingMethods() {
            Type weavedPropertyType = null;
            var propertyAspectArgMapperTypeBuilder = typeof(object).DefineType("PropertyArgsMapper".ToUniqueName(), attributes: typeAttrs);

            BuildPropertyMappingMethods(propertyAspectArgMapperTypeBuilder, typeof(IActionArgs<>), typeof(IPropertyArg<>), "Arg1");
            BuildPropertyMappingMethods(propertyAspectArgMapperTypeBuilder, typeof(IFunctionArgs<>), typeof(IPropertyArg<>), "ReturnValue");
            weavedPropertyType = propertyAspectArgMapperTypeBuilder.CreateType();

            propertyAspectArgMapperMethodsDictionary = weavedPropertyType.GetMethods(weavedMethodsFlags)
                                                                         .ToDictionary(method => {
                                                                             var parameters = method.GetParameters();
                                                                             var firstParam = parameters[0].ParameterType.GetGenericTypeDefinition();
                                                                             var secondParam = parameters[1].ParameterType.GetGenericTypeDefinition();

                                                                             return Tuple.Create(firstParam, secondParam);
                                                                         });
        }

        private void BuildPropertyMappingMethods(TypeBuilder typeBuilder, Type fromArgType, Type propertyArgType, string fromArgTypePropertyName) {
            Type fromArgumentType = null;
            Type propertyArgumentType = null;
            ILGenerator fromArgTypeILGenerator = null;
            ILGenerator fromPropertyILGenerator = null;
            GenericTypeParameterBuilder[] fromArgTypeGenericParameters = null;
            GenericTypeParameterBuilder[] propertyArgTypeGenericParameters = null;
            var fromArgTypeMethodBuilder = typeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);
            var fromPropertyMethodBuilder = typeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);

            fromArgTypeGenericParameters = fromArgTypeMethodBuilder.DefineGenericParameters(new[] { "TArg" });
            propertyArgTypeGenericParameters = fromPropertyMethodBuilder.DefineGenericParameters(new[] { "TArg" });
            fromArgumentType = fromArgType.MakeGenericType(fromArgTypeGenericParameters);
            propertyArgumentType = propertyArgType.MakeGenericType(propertyArgTypeGenericParameters);
            fromArgTypeMethodBuilder.SetParameters(new[] { fromArgumentType, propertyArgumentType });
            fromPropertyMethodBuilder.SetParameters(new[] { propertyArgumentType, fromArgumentType });
            fromArgTypeMethodBuilder.SetReturnType(typeof(void));
            fromPropertyMethodBuilder.SetReturnType(typeof(void));

            fromArgTypeILGenerator = fromArgTypeMethodBuilder.GetILGenerator();
            fromPropertyILGenerator = fromPropertyMethodBuilder.GetILGenerator();

            fromArgTypeILGenerator.Emit(OpCodes.Ldarg_1);
            fromArgTypeILGenerator.Emit(OpCodes.Ldarg_0);
            fromArgTypeILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(fromArgumentType, fromArgType.GetProperty(fromArgTypePropertyName).GetGetMethod()));
            fromArgTypeILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(propertyArgumentType, propertyArgType.GetProperty("Value").GetSetMethod()));

            fromPropertyILGenerator.Emit(OpCodes.Ldarg_1);
            fromPropertyILGenerator.Emit(OpCodes.Ldarg_0);
            fromPropertyILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(propertyArgumentType, propertyArgType.GetProperty("Value").GetGetMethod()));
            fromPropertyILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(fromArgumentType, fromArgType.GetProperty(fromArgTypePropertyName).GetSetMethod()));

            fromArgTypeILGenerator.Emit(OpCodes.Ldarg_1);
            fromArgTypeILGenerator.Emit(OpCodes.Ldarg_0);
            fromArgTypeILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(fromArgumentType, fromArgType.GetProperty("Method").GetGetMethod()));
            fromArgTypeILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(propertyArgumentType, propertyArgType.GetProperty("Method").GetSetMethod()));

            fromPropertyILGenerator.Emit(OpCodes.Ldarg_1);
            fromPropertyILGenerator.Emit(OpCodes.Ldarg_0);
            fromPropertyILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(propertyArgumentType, propertyArgType.GetProperty("Method").GetGetMethod()));
            fromPropertyILGenerator.Emit(OpCodes.Callvirt, TypeBuilder.GetMethod(fromArgumentType, fromArgType.GetProperty("Method").GetSetMethod()));

            fromArgTypeILGenerator.Emit(OpCodes.Ret);
            fromPropertyILGenerator.Emit(OpCodes.Ret);
        }

        private void BuildNonGenericTypeMethod(TypeBuilder typeBuilder, int numberOfArgs, Func<int, Type> resolveArgsFn) {
            Type argumentType = null;
            ILGenerator ilGenerator = null;
            PropertyInfo methodProperty = null;
            var methodBuilder = typeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);

            argumentType = resolveArgsFn(numberOfArgs);
            methodBuilder.SetParameters(new[] { argumentType, argumentType });
            ilGenerator = methodBuilder.GetILGenerator();
            methodProperty = argumentType.GetProperty("Method");

            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Callvirt, methodProperty.GetGetMethod());
            ilGenerator.Emit(OpCodes.Callvirt, methodProperty.GetSetMethod());
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

        public MethodInfo GetPropertyMappingArgs(Type fromType, Type toType) {
            var tuple = Tuple.Create(fromType.GetGenericTypeDefinition(), toType.GetGenericTypeDefinition());

            return propertyAspectArgMapperMethodsDictionary[tuple];
        }

        public MethodInfo GetActionMappingArgs(int argumentCount) {
            return actionAspectArgMapperMethodsDictionary[argumentCount];
        }

        public MethodInfo GetFunctionMappingArgs(int argumentCount) {
            return funcAspectArgMapperMethodsDictionary[argumentCount];
        }
    }
}



