using NCop.Aspects.Aspects;
using NCop.Composite.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingMethodInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
        protected readonly Type topAspectInScopeArgType = null;
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal BindingMethodInterceptionAspectWeaver(Type topAspectInScopeArgType, IMethodAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
            ArgumentType = argumentsWeavingSettings.ArgumentType;
            argumentsWeavingSettings.BindingsDependency = weavedType;
            argumentsWeaver = new BindingMethodInterceptionArgumentsWeaver(aspectDefinition.Method, topAspectInScopeArgType, argumentsWeavingSettings, aspectWeavingSettings);
            methodScopeWeavers.Add(new NestedAspectArgsMappingWeaver(topAspectInScopeArgType, aspectWeavingSettings, argumentsWeavingSettings));
            weaver = new MethodScopeWeaversQueue(methodScopeWeavers);
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
        }
    }
}
