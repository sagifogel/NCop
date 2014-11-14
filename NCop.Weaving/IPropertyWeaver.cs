using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
    public interface IPropertyWeaver : IWeaver
    {
        bool CanRead { get; }
        bool CanWrite { get; }


        IMethodWeaver GetGetMethod();
        IMethodWeaver GetSetMethod();
    }
}
