using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public interface IAspectBuilderProvider
    {
        IAspectBuilderCollection Builders { get; }
    }
}
