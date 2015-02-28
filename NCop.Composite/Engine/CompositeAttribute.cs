using System;

namespace NCop.Composite.Engine
{
    [AttributeUsage(AttributeTargets.Interface)]
    public abstract class CompositeAttribute : Attribute
    {
        public Type As { get; set; }
    }
}
