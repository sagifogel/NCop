using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Weaving;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositePropertyWeavingSettings : IAspectPropertyWeavingSettings
    {
        public IAspectRepository AspectRepository { get; set; }
        public IAspectArgsMapper AspectArgsMapper { get; set; }
        public IPropertyWeavingSettings WeavingSettings { get; set; }
        public ILocalBuilderRepository LocalBuilderRepository { get; set; }
        public IByRefArgumentsStoreWeaver ByRefArgumentsStoreWeaver { get; set; }
    }
}
