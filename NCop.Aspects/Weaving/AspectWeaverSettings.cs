using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectWeaverSettings : IAspectWeaverSettings
    {
        internal static AspectWeaverSettings Empty = new AspectWeaverSettings();

        public AspectWeaverSettings() { 
        }

        public IContextWeaver ContextWeaver { get; internal set; }
        public IAspectRepository AspectRepository { get; internal set; }
    }
}
