using NCop.Core.Extensions;
using NCop.Core.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    public class CompositeMethodWeaver : IMethodWeaver
    {
        private IMethodWeaver _first = null;
        private IEnumerable<IMethodWeaver> _methodWeavers = null;

        public CompositeMethodWeaver(MethodInfo method, IEnumerable<IMethodWeaver> methodWeavers) {
            MethodInfo = method;
            _first = methodWeavers.First();
            _methodWeavers = methodWeavers;
        }

        public MethodInfo MethodInfo { get; private set; }

        public MethodBuilder DefineMethod() {
            return _first.DefineMethod();
        }

        public ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            _methodWeavers.ForEach(m => m.WeaveMethodScope(ilGenerator, typeDefinition));

            return ilGenerator;
        }

        public void WeaveEndMethod(ILGenerator ilGenerator) {
            _first.WeaveEndMethod(ilGenerator);
        }
    }
}
