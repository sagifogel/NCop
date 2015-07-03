using NCop.Aspects.Engine;
using NCop.Core;

namespace NCop.Composite.Engine
{
    public interface ICompositeEventMap : IEventMap, IHasAspectDefinitions
    {
        ICompositeEventFragmentMap AddEventFragmentMap { get; }
        ICompositeEventFragmentMap RemoveEventFragmentMap { get; }
        ICompositeEventFragmentMap InvokeEventFragmentMap { get; }
    }
}
