using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public class PointcutStore : ConcurrentDictionary<string, IList<IPointcut>>
    {
        
    }
}
