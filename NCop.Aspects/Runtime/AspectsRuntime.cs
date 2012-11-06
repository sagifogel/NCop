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
    public class AspectsRuntime : IAspectRuntime
    {
        private IWeaver _weaver = null;
        private AspectsRuntimeSettings _settings = null;
        private IEnumerable<Assembly> _assemblies = null;
        private WeaverVisitor _visitor = new WeaverVisitor();
        
        public AspectsRuntime(AspectsRuntimeSettings settings) {
            Contract.Assert(settings != null, "Runtime Settings can not be null.");
            Contract.Assert(settings.Weaver != null, "Weaver can not be null.");
            
            IWeaverAcceptVisitor acceptVisitor = null;

            _settings = settings;
            settings.Assemblies = settings.Assemblies ?? GetAssemblies();
            settings.AspectBuilderRegistry = GetBuilderRegistry();
            acceptVisitor = settings.Weaver as IWeaverAcceptVisitor;
            _weaver = acceptVisitor.Accept(_visitor, settings);
        }

        private IEnumerable<Assembly> GetAssemblies() {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !AspectsRuntimeSettings.IgnoredAssemblies.Contains(a));
        }

        private IAspectBuilderRegistry GetBuilderRegistry() {
            return _settings.AspectBuilderRegistry ?? new AttributeAspectBuilderRegistry(_assemblies);
        }

        private IWeaver WrapWeaver(RuntimeWeaver weaver) {
            return new RuntimeMixinsWeaver(weaver, _settings);
        }

        public void Run() {

        }
    }
}
