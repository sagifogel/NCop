using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Aspects
{
    internal class OnMethodBoundaryAspectDefinition : AbstractAspectDefinition
    {
        private readonly OnMethodBoundaryAspectAttribute aspect = null;

        internal OnMethodBoundaryAspectDefinition(OnMethodBoundaryAspectAttribute aspect, Type aspectDeclaringType)
            : base(aspect, aspectDeclaringType) {
            this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.OnMethodBoundaryAspect;
            }
        }

        public override IAspectExpressionBuilder Accept(AspectVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }

        protected override void BulidAdvices() {
            Aspect.AspectType
                 .GetOverridenMethods()
                 .ForEach(method => {
                     TryBulidAdvice<OnMethodEntryAdviceAttribute>(method, (advice, mi) => {
                         return new OnMethodEntryAdviceDefinition(advice, mi);
                     });

                     TryBulidAdvice<OnMethodSuccessAdviceAttribute>(method, (advice, mi) => {
                         return new OnMethodSuccessAdviceDefinition(advice, mi);
                     });

                     TryBulidAdvice<OnMethodExceptionAdviceAttribute>(method, (advice, mi) => {
                         return new OnMethodExceptionAdviceDefinition(advice, mi);
                     });

                     TryBulidAdvice<FinallyAdviceAttribute>(method, (advice, mi) => {
                         return new FinallyAdviceDefinition(advice, mi);
                     });
                 });
        }
    }
}
