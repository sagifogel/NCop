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
    internal class CompositeWeavinsSettingsImpl : ICompositeWeavingSettings
    {   
        public Type CompositeType { get; set; }
        public ITypeMap MixinsMap { get; set; }
        public IAspectsMap AspectsMap { get; set; }
        public IAspectArgsMapper AspectArgsMapper { get; set; }
        public IAspectRepository AspectRepository { get; set; }
        public INCopDependencyAwareRegistry Registry { get; set; }
        public IAspectMemebrsCollection AspectMemebrsCollection { get; set; }
    }
}
