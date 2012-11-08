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
            settings.AspectBuilderProvider = GetBuilderProvider();
            acceptVisitor = settings.Weaver as IWeaverAcceptVisitor;
            _weaver = acceptVisitor.Accept(_visitor, settings);
        }

        private IEnumerable<Assembly> GetAssemblies() {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(assembly => !AspectsRuntimeSettings.IgnoredAssemblies.Contains(assembly));
        }

        private IAspectBuilderProvider GetBuilderProvider() {
            return _settings.AspectBuilderProvider ?? new AttributeAspectBuilderRegistry(_assemblies);
        }

        public void Run() {
            _weaver.Weave();
        }
    }
}
