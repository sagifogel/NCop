using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class TopAspectExpression : IAspectExpression
	{
		private readonly IAspectExpression aspectExpression = null;

		internal TopAspectExpression(IAspectExpression aspectExpression) {
			this.aspectExpression = aspectExpression;
		}

		public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
			return new TopAspectWeaver(aspectExpression.Reduce(settings));
		}
	}
}
