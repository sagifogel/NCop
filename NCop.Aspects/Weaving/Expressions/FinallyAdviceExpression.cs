using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class FinallyAdviceExpression : AbstractAdviceExpression
    {
        internal FinallyAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.FinallyAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IMethodLocalWeaver aspectArgsLocalWeaver) {
            return new FinallyAdviceWeaver(aspectArgsLocalWeaver);
        }
    }
}