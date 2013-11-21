using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnMethodExceptionAdviceExpression : AbstractAdviceExpression
    {
		public OnMethodExceptionAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.OnMethodExceptionAdvice;
			}
		}
		
		public override IMethodScopeWeaver Reduce() {
            throw new NotImplementedException();
        }
    }
}