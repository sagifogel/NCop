using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
	class TopAspectWeaver : IAspectWeaver
	{
		private readonly IAspectWeaver decoratedWeaver = null;

		public TopAspectWeaver(IAspectWeaver decoratedWeaver) {
			this.decoratedWeaver = decoratedWeaver;		
		}

		public ILGenerator Weave(ILGenerator ilGenerator) {
			return decoratedWeaver.Weave(ilGenerator);
		}
	}
}
