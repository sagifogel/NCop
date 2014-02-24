using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.Weaving
{
    interface ICompositeWeavingSettings : IAspectWeavingServices
    {
        Type CompositeType { get; }
        ITypeMap MixinsMap { get; }
        INCopRegistry Registry { get; }
        IAspectsMap AspectsMap { get; }
        IAspectMemebrsCollection AspectMemebrsCollection { get; }
    }
}
