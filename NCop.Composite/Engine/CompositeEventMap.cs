using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Composite.Engine
{

    public class CompositeEventMap : ICompositeEventMap
    {
        public CompositeEventMap(IEnumerable<ICompositeEventFragmentMap> eventMaps) {
            var eventMapVisitor = new CompositeEventMapVisitor();

            eventMaps.ForEach(frag => frag.Accept(eventMapVisitor));
            AddEventFragmentMap = eventMapVisitor.AddEventFragmentMap;
            HasAspectDefinitions = eventMapVisitor.HasAspectDefinitions;
            RemoveEventFragmentMap = eventMapVisitor.RemoveEventFragmentMap;
            InvokeEventFragmentMap = eventMapVisitor.InvokeEventFragmentMap;
            ContractType = AddEventFragmentMap.ContractType;
            ContractMember = AddEventFragmentMap.ContractMember;
            ImplementationType = AddEventFragmentMap.ImplementationType;
            ImplementationMember = AddEventFragmentMap.ImplementationMember;
        }

        public Type ContractType { get; private set; }
        
        public Type ImplementationType { get; private set; }
        
        public EventInfo ContractMember { get; private set; }

        public bool HasAspectDefinitions { get; private set; }

        public EventInfo ImplementationMember { get; private set; }
        
        public ICompositeEventFragmentMap AddEventFragmentMap { get; private set; }

        public ICompositeEventFragmentMap RemoveEventFragmentMap { get; private set; }

        public ICompositeEventFragmentMap InvokeEventFragmentMap { get; private set; }
    }
}
