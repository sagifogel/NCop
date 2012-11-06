using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public class RuntimeWeaver : IWeaverAcceptVisitor
    {
        internal IAspectBuilderRegistry Registry = null;
        internal IEnumerable<Assembly> Assemblies = null;

        public virtual void Weave() {
            
        }

        public IWeaver Accept(WeaverVisitor visitor, AspectsRuntimeSettings settings) {
            return visitor.Visit(this, settings);
        }
    }
}
