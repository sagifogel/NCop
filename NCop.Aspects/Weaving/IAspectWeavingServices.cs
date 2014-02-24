using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    public interface IAspectWeavingServices
    {
        IAspectArgsMapper AspectArgsMapper { get; }
        IAspectRepository AspectRepository { get; }
    }
}
