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
    public class RuntimeMixinsWeaver : IWeaverAcceptVisitor
    {
        private RuntimeWeaver _weaver = null;

        public RuntimeMixinsWeaver(RuntimeWeaver weaver, AspectsRuntimeSettings settings) {
            _weaver = weaver;
            _weaver.Assemblies = settings.Assemblies;
            weaver.BuilderProvider = settings.AspectBuilderProvider;
        }

        public void Weave() {
            MapTypes();
            _weaver.Weave();
        }

        private void MapTypes() {
            var composites = _weaver.Assemblies
                                    .SelectMany(a => a.GetTypes())
                                    .Where(type => type.IsNCopDefined<CompositeAttribute>())
                                    .Select(type => new CompositeMetadata(type));

            foreach (var item in composites) {
                
            }
        }

        public IWeaver Accept(WeaverVisitor visitor, AspectsRuntimeSettings settings) {
            return this;
        }
    }
}
