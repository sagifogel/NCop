using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodIntercpetionArgumentsWeaver : AbstractArgumentsWeaver
    {
        private readonly Type topAspectInScopeArgType = null;

        internal NestedMethodIntercpetionArgumentsWeaver(MethodInfo methodInfo, Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(methodInfo, argumentWeavingSettings, aspectWeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }

        public override void Weave(ILGenerator ilGenerator) {
            FieldBuilder contractFieldBuilder = null;
            var declaredLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var ctorInterceptionArgs = ArgumentType.GetConstructors()[0];
            var argsLocalBuilder = LocalBuilderRepository.Get(topAspectInScopeArgType);
            var methodPropoertyInfo = topAspectInScopeArgType.GetProperty("Method");
            
            LocalBuilderRepository.Add(declaredLocalBuilder);
            contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, methodPropoertyInfo.GetGetMethod());
            ilGenerator.Emit(OpCodes.Ldsfld, BindingsDependency);

            Parameters.ForEach(1, (parameter, i) => {
                var property = topAspectInScopeArgType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(declaredLocalBuilder);
        }
    }
}