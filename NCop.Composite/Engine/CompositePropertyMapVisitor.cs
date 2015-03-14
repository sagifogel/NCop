using System;
using NCop.Composite.Weaving;
using NCop.Weaving;

namespace NCop.Composite.Engine
{
    internal class CompositePropertyMapVisitor : ICompositePropertyMapVisitor
    {
        public Type ContractType { get; set; }
        public ICompositePropertyFragmentMap SetPropertyFragmentMap { get; private set; }
        public ICompositePropertyFragmentMap GetPropertyFragmentMap { get; private set; }

        public void Visit(GetCompositePropertyMap propertyMap) {
            GetPropertyFragmentMap = propertyMap;
            ContractType = propertyMap.ContractType;
        }

        public void Visit(SetCompositePropertyMap propertyMap) {
            SetPropertyFragmentMap = propertyMap;
            ContractType = propertyMap.ContractType;
        }
    }
}
