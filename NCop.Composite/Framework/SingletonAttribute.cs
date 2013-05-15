using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Framework
{
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
    public class SingletonAttribute : Attribute
    {
    }
}
