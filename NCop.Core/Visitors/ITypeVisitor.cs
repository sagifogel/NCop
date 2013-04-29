using System;
using System.Reflection;

namespace NCop.Core.Visitors
{
    internal interface ITypeVisitor
    {
        void Visit(Type type);
        void Visit(MethodInfo method);
        void Visit(PropertyInfo property);
    }
}
