using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public interface IAspectWeavingSettings
    {
        IAspectRepository AspectRepository { get; }
        IAspectArgumentWeaver ArgumentsWeaver { get; }
    }
}
