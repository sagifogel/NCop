using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Engine
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public abstract class CompositeAttribute : Attribute
    {
    }
}
