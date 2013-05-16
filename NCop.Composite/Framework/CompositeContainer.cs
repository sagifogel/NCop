using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;
using NCop.IoC.Fluent;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Composite.Engine;

namespace NCop.Composite.Framework
{
    public class CompositeContainer : AbstractNCopContainer, IContainerConfigurator
    {
        public CompositeContainer(RuntimeSettings settings = null) {
            var composite = new CompositeRuntime(settings, registry);

            composite.Run();
        }

        protected override IContainerRegistry CreateRegistry() {
            return new CompositeRegistry();
        }

        public void Configure(Action<IFluentRegistry> registrationAction = null) {
            ConfigureInternal(registrationAction);
        }
    }
}
