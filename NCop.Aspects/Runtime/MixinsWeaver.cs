using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Runtime
{
    public class MixinsWeaver : IWeaver
    {
        private AspectBuilderRegistry _registry = null;

        public MixinsWeaver() {
            _registry = new AspectBuilderRegistry();
        }

        public void Weave() {

        }
    }
}
