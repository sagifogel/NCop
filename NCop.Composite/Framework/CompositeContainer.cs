using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;
using NCop.IoC.Fluent;
using NCop.Core;
using NCop.Core.Extensions;

namespace NCop.Composite.Framework
{
    public class CompositeContainer : AbstractContainer, IContainerConfigurator
    {
        public CompositeContainer(RuntimeSettings settings = null) {
            var reflectionRegistry = new ReflectionRegistry(registry);
            var composite = new CompositeRuntime(settings, reflectionRegistry);

            composite.Run();
        }

        public INCopContainer Configure(Action<IFluentRegistry> registrationAction = null) {
            ConfigureInternal(registrationAction);

            return this;
        }
    }
}
