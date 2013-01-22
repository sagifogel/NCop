using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Core.Visitors
{
    public interface IEnumerableProjectionTypeVisitor<T> : IProjectionTypeVisitor<IEnumerable<T>>
    {
        
    }
}
