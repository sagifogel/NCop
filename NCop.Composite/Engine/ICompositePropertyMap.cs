using System;

namespace NCop.Composite.Engine
{
    public interface ICompositePropertyMap
    {
        Type ContractType { get; }
        ICompositePropertyFragmentMap GetPropertyFragmentMap { get; }
        ICompositePropertyFragmentMap SetPropertyFragmentMap { get; }
    }
}
