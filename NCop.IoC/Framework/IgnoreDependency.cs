using System;

namespace NCop.IoC.Framework
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreDependency : Attribute
    {
    }
}
