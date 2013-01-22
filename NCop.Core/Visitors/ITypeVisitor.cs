using System;
using System.Reflection;

namespace NCop.Core.Visitors
{
    public interface ITypeVisitor
    {
        void Visit(Type type);
        void Visit(MethodInfo method);
        void Visit(PropertyInfo property);
    }
}
