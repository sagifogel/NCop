using NCop.Aspects.Aspects;
using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IAspectCollection : IReadOnlyCollection<IAspect>
    {
    }
}
