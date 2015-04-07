using System;

namespace NCop.IoC.Framework
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    public class IgnoreDependencyAttribute : Attribute
    {
    }
}
