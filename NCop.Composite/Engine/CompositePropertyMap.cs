using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Composite.Engine
{
    public class CompositePropertyMap : ICompositePropertyMap
    {
        public CompositePropertyMap(IEnumerable<ICompositePropertyFragmentMap> propertyMaps) {
            var propertyMapVisitor = new CompositePropertyMapVisitor();

            propertyMaps.ForEach(fragment => fragment.Accept(propertyMapVisitor));
            ContractType = propertyMapVisitor.ContractType;
            GetPropertyFragmentMap = propertyMapVisitor.GetPropertyFragmentMap;
            SetPropertyFragmentMap = propertyMapVisitor.SetPropertyFragmentMap;
        }

        public Type ContractType { get; private set; }

        public ICompositePropertyFragmentMap GetPropertyFragmentMap { get; private set; }

        public ICompositePropertyFragmentMap SetPropertyFragmentMap { get; private set; }
    }
}
