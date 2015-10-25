using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.IoC;
using System;

namespace NCop.Composite.Weaving
{
    interface ICompositeWeavingSettings : IAspectWeavingServices
    {
        Type CompositeType { get; }
        ITypeMapCollection MixinsMap { get; }
        IAspectsMap AspectsMap { get; }
        INCopDependencyAwareRegistry Registry { get; }
        IAspectMemebrsCollection AspectMemebrsCollection { get; }
    }
}
