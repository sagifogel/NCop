using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface ITypesVisitor<out T>
    {
        IEnumerable<T> Visit(Type type);
        IEnumerable<T> Visit(FieldInfo[] fields);
        IEnumerable<T> Visit(MethodInfo[] methods);
        IEnumerable<T> Visit(ConstructorInfo[] ctors);
        IEnumerable<T> Visit(PropertyInfo[] properties);
    }
}
