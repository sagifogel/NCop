using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class BindingSettings : IAspectWeavingSettings
    {
        public Type BindingType { get; set; }
        public IWeavingSettings WeavingSettings { get; set; }
        public IArgumentsWeaver ArgumentsWeaver { get; set; }
        public IAspectArgsMapper AspectArgsMapper { get; set; }

        public IAspectRepository AspectRepository {
            get { throw new NotImplementedException(); }
        }
    }
}
