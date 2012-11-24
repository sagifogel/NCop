using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using NCop.Core.Framework;
using NCop.Core.Engine;

namespace NCop.Aspects.Runtime
{
    internal class RuntimeMixinsWeaver : IWeaverAcceptVisitor
    {
        private RuntimeWeaver _weaver = null;

        internal RuntimeMixinsWeaver(RuntimeWeaver weaver, AspectsRuntimeSettings settings) {
            _weaver = weaver;
            _weaver.Assemblies = settings.Assemblies;
            weaver.BuilderProvider = settings.AspectBuilderProvider;
        }

        public void Weave() {
            MapTypes();
            _weaver.Weave();
        }

        private void MapTypes() {
            var composites = _weaver.Assemblies.SelectMany(assembly => {
                return assembly.GetCompositesMetadata();
            });

            foreach (var item in composites) {

            }
        }

        public IWeaver Accept(WeaverVisitor visitor, AspectsRuntimeSettings settings) {
            return this;
        }
    }
}
