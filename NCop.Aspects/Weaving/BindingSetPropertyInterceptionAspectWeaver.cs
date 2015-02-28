using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingSetPropertyInterceptionAspectWeaver : AbstractInterceptionAspectWeaver
    {
        internal BindingSetPropertyInterceptionAspectWeaver(IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
        }

        protected override IAdviceExpression ResolveInterceptionAdviceExpression() {
            throw new NotImplementedException();
        }
        
        public override void Weave(ILGenerator ilGenerator) {
            throw new NotImplementedException();
        }
    }
}
