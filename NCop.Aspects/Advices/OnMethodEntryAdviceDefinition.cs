using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Advices
{
	internal class OnMethodEntryAdviceDefinition : AbstractAdviceDefinition
	{
		private readonly OnMethodEntryAdviceAttribute advice = null;

		public OnMethodEntryAdviceDefinition(OnMethodEntryAdviceAttribute advice, MethodInfo adviceMethod)
			: base(advice, adviceMethod) {
			this.advice = advice;
		}

		public override IExpressionReducer Accept(AdviceVisitor visitor) {
			return visitor.Visit(advice).Invoke(this);
		}
	}
}