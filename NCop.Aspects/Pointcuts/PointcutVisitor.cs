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
        IPointcut Visit(FieldInfo[] fields);
        IPointcut Visit(MethodInfo[] methods);
        IPointcut Visit(ConstructorInfo[] ctors);
        IPointcut Visit(PropertyInfo[] properties);
    }
}
