using System;

namespace NCop.Aspects.Advices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
    public abstract class AdviceAttribute : Attribute, IAdvice
    {
    }
}
