using NCop.Weaving;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
	internal class BeginExceptionBlockMethodScopeWeaver : IMethodScopeWeaver
	{
		internal BeginExceptionBlockMethodScopeWeaver() {
		}

		public void Weave(ILGenerator ilGenerator) {
			ilGenerator.BeginExceptionBlock();
		}
	}
}
