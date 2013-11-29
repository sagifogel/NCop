using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public interface IAspectRepository
    {
        Type GetByType(Type type);
    }
}
