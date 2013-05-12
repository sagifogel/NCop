using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Framework
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreDependency : Attribute
    {
    }
}
