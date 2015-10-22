using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Core.Runtime
{
    public interface ITypeFactory
    {
        IEnumerable<Type> Types { get; }
    }
}
