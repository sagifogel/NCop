using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Weaving.Expressions;
using NCop.Aspects.Weaving;

namespace NCop.Aspects.Advices
{
	internal class OnMethodExceptionAdviceDefinition : AbstractAdviceDefinition
	{
		private readonly OnMethodExceptionAdviceAttribute advice = null;

		public OnMethodExceptionAdviceDefinition(OnMethodExceptionAdviceAttribute advice, MethodInfo adviceMethod)
			: base(advice, adviceMethod) {
			this.advice = advice;
		}

        public override IAdviceExpression Accept(AdviceVisitor visitor) {
			return visitor.Visit(advice).Invoke(this);
		}

        public override void Accept(AdviceDiscoveryVisitor visitor) {
            visitor.Visit(advice);
        }
	}
}