using System;

namespace NCop.Composite.Engine
{
    internal class CompositePropertyMapVisitor : ICompositePropertyMapVisitor
    {
        public void Visit(CompositeGetPropertyMap propertyMap) {
            GetPropertyFragmentMap = propertyMap;
            ContractType = propertyMap.ContractType;
        }

        public void Visit(CompositeSetPropertyMap propertyMap) {
            SetPropertyFragmentMap = propertyMap;
            ContractType = propertyMap.ContractType;
        }

        public Type ContractType { get; set; }

        public ICompositePropertyFragmentMap SetPropertyFragmentMap { get; private set; }
        
        public ICompositePropertyFragmentMap GetPropertyFragmentMap { get; private set; }
    }
}
