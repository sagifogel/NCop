using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class OnMethodEntryAdviceExpression : AbstractAdviceExpression
    {
        internal OnMethodEntryAdviceExpression(IAdviceDefinition adviceDefinition)
			: base(adviceDefinition) {
        }

		protected override AdviceType AdviceType {
			get {
				return AdviceType.OnMethodEntryAdvice;
			}
		}

        public override IMethodScopeWeaver Reduce(IMethodLocalWeaver aspectArgsLocalWeaver) {
            return new OnMethodEntryAdviceWeaver(aspectArgsLocalWeaver);
        }
    }
}
