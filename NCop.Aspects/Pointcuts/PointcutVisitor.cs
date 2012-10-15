using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Pointcuts
{
    public interface IPointcutVisitor
    {
        IEnumerable<IPointcut> Visit(FieldInfo[] fields);
        IEnumerable<IPointcut> Visit(MethodInfo[] methods);
        IEnumerable<IPointcut> Visit(ConstructorInfo[] ctors);
        IEnumerable<IPointcut> Visit(PropertyInfo[] properties);
    }
}
