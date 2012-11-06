using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Runtime
{
    public class RuntimeMixinsWeaver : IWeaverAcceptVisitor
    {
        private RuntimeWeaver _weaver = null;

        public RuntimeMixinsWeaver(RuntimeWeaver weaver, AspectsRuntimeSettings settings) {
            _weaver = weaver;
        }

        public void Weave() {
            MapTypes();
            _weaver.Weave();
        }

        private void MapTypes() {
            _weaver.Assemblies.SelectMany(a => a.GetTypes())
                       .ForEach(type => {

                       });
        }

        public IWeaver Accept(WeaverVisitor visitor, AspectsRuntimeSettings settings) {
            return this;
        }
    }
}
