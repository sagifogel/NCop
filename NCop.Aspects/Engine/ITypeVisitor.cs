using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface ITypeVisitor<T> : NCop.Core.ITypeVisitor<IEnumerable<T>>
    {
        
    }
}
