
namespace NCop.Composite.Engine
{
    internal class CompositeEventMapVisitor : ICompositeEventMapVisitor
    {
        public void Visit(CompositeAddEventMap propertyMap) {
            AddEventFragmentMap = propertyMap;
            HasAspectDefinitions = HasAspectDefinitions || AddEventFragmentMap.HasAspectDefinitions;
        }

        public void Visit(CompositeRemoveEventMap removeEventFragmentMap) {
            RemoveEventFragmentMap = removeEventFragmentMap;
            HasAspectDefinitions = HasAspectDefinitions || RemoveEventFragmentMap.HasAspectDefinitions;
        }

        public void Visit(CompositeInvokeEventMap invokeEventFragmentMap) {
            InvokeEventFragmentMap = invokeEventFragmentMap;
            HasAspectDefinitions = HasAspectDefinitions || InvokeEventFragmentMap.HasAspectDefinitions;
        }

        public bool HasAspectDefinitions { get; private set; }

        public ICompositeEventFragmentMap AddEventFragmentMap { get; private set; }

        public ICompositeEventFragmentMap RemoveEventFragmentMap { get; private set; }

        public ICompositeEventFragmentMap InvokeEventFragmentMap { get; private set; }
    }
}
