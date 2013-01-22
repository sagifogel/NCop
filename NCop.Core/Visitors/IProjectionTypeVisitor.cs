using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core.Visitors
{
    public interface IProjectionTypeVisitor<out T>
    {
        T Visit(Type type);
        T Visit(MethodInfo[] methods);
        T Visit(PropertyInfo[] properties);
    }
}
