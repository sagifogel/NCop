using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
	internal class NullObjectByRefArgumentsStoreWeaver : IByRefArgumentsStoreWeaver
	{
		public static NullObjectByRefArgumentsStoreWeaver Empty = new NullObjectByRefArgumentsStoreWeaver();

		private NullObjectByRefArgumentsStoreWeaver() {
		}

		public bool Contains(int argPosition) {
			return false;
		}

		public bool ContainsByRefParams {
			get {
				return false;
			}
		}

		public void StoreArgsIfNeeded(ILGenerator ilGenerator) {
		}

		public void RestoreArgsIfNeeded(ILGenerator ilGenerator) {
		}

		public void EmitLoadLocalAddress(ILGenerator ilGenerator, int argPosition) {
		}
	}
}
