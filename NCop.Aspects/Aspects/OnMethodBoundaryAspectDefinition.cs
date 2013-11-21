using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    internal class OnMethodBoundaryAspectDefinition : AspectDefinition
    {
        private readonly OnMethodBoundaryAspectAttribute aspect = null;

        internal OnMethodBoundaryAspectDefinition(OnMethodBoundaryAspectAttribute aspect)
            : base(aspect) {
            this.aspect = aspect;
        }

        public override IHasAspectExpression Accept(AspectVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }

        public override AspectType AspectType {
            get { 
                return AspectType.OnMethodBoundaryAspect; 
            }
        }
    }
}
