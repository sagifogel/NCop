using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
        private readonly IArgumentsWeaver argumentsWeaver = null;

        internal NestedMethodInterceptionAspectWeaver(Type topAspectInScopeArgType, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            var argumentWeavingSettings = aspectDefinition.ToArgumentsWeavingSettings();

            argumentWeavingSettings.BindingsDependency = weavedType;
            argumentsWeaver = new NestedMethodIntercpetionArgumentsWeaver(aspectDefinition.Method, topAspectInScopeArgType, aspectWeavingSettings, argumentWeavingSettings);
            methodScopeWeavers.Add(new NestedAspectArgsMappingWeaver(topAspectInScopeArgType, aspectWeavingSettings, argumentsWeavingSettings));
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
