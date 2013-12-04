using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectDecoratorWeaver : IAspcetWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

		public AspectDecoratorWeaver(IWeavingSettings weavingSettings) {
			Name = weavingSettings.MethodInfoImpl.Name;
			weaver = new MethodDecoratorScopeWeaver(weavingSettings);
        }

        public ILGenerator Weave(ILGenerator iLGenerator) {
            return weaver.Weave(iLGenerator);
        }

        public string Name { get; private set; }
    }
}
