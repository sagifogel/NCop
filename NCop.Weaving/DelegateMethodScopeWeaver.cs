using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Weaving
{
    public class DelegateMethodScopeWeaver : IMethodScopeWeaver
    {
        private readonly Action<ILGenerator> weaveAction = null;

        public DelegateMethodScopeWeaver(Action<ILGenerator> weaveAction) {
            this.weaveAction = weaveAction;
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            weaveAction(ilGenerator);

            return ilGenerator;
        }
    }
}
