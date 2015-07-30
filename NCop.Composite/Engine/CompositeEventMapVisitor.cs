
namespace NCop.Composite.Engine
{
    internal class CompositeEventMapVisitor : ICompositeEventMapVisitor
    {
        public void Visit(CompositeAddEventMap propertyMap) {
            AddEventFragmentMap = propertyMap;
            HasAspectDefinitions = HasAspectDefinitions || AddEventFragmentMap.HasAspectDefinitions;
        }

        public void Visit(CompositeRaiseEventMap raiseEventFragmentMap) {
            RaiseEventFragmentMap = raiseEventFragmentMap;
            HasAspectDefinitions = HasAspectDefinitions || RaiseEventFragmentMap.HasAspectDefinitions;
        }

        public void Visit(CompositeRemoveEventMap removeEventFragmentMap) {
            RemoveEventFragmentMap = removeEventFragmentMap;
            HasAspectDefinitions = HasAspectDefinitions || RemoveEventFragmentMap.HasAspectDefinitions;
        }

        public bool HasAspectDefinitions { get; private set; }

        public ICompositeEventFragmentMap AddEventFragmentMap { get; private set; }

        public ICompositeEventFragmentMap RaiseEventFragmentMap { get; private set; }

        public ICompositeEventFragmentMap RemoveEventFragmentMap { get; private set; }
    }
}
