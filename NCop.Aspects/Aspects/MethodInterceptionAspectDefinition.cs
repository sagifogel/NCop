using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    internal class MethodInterceptionAspectDefinition : AspectDefinition
    {
        private readonly MethodInterceptionAspectAttribute aspect = null;

        internal MethodInterceptionAspectDefinition(MethodInterceptionAspectAttribute aspect)
            : base(aspect) {
                this.aspect = aspect;
        }

        public override IAspectExpression Accept(AspectVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }

        public override AspectType AspectType {
            get {
                return AspectType.MethodInterceptionAspect;
            }
        }
    }
}
