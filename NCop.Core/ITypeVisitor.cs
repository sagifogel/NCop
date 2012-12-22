using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
    public interface ITypeVisitor<out T>
    {
        BindingFlags Flags { get; }
        T Visit(Type type);
        T Visit(MethodInfo[] methods);
        T Visit(PropertyInfo[] properties);
    }
}
