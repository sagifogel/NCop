using System;

namespace NCop.IoC.Framework
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Property | AttributeTargets.GenericParameter | AttributeTargets.Parameter)]
    public class DependencyAttribute : Attribute
    {
    }
}
