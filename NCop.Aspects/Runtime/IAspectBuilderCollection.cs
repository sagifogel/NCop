using NCop.Aspects.Engine;
using NCop.Core;
using NCop.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public interface IAspectBuilderCollection : IReadOnlyCollection<IAspectBuilder>
    {
    }
}
