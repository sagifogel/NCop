using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;
using NCop.IoC.Fluent;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Composite.Engine;
using System.Threading;

namespace NCop.Composite.Framework
{
    public class CompositeContainer : AbstractNCopContainer, IContainerConfigurator<IFluentRegistry>
    {
        private int locked = 0;
        private readonly RuntimeSettings settings = null;
        private readonly CompositeContainer parentContainer = null;
        private readonly Stack<CompositeContainer> childContainers = new Stack<CompositeContainer>();

        public CompositeContainer(RuntimeSettings settings = null)
            : this(null, settings) {
        }

        internal CompositeContainer(CompositeContainer parentContainer, RuntimeSettings settings = null) {
            this.parentContainer = parentContainer;

            var composite = new CompositeRuntime(settings, registry);
            this.settings = settings;

            composite.Run();
        }

        protected override IContainerRegistry CreateRegistry() {
            return new CompositeRegistry();
        }

        public CompositeContainer CreateChildContainer() {
            CompositeContainer container = null;

            lock (childContainers) {
                childContainers.Push(container = new CompositeContainer(this, settings));
            }

            return container;
        }

        public void Configure(Action<IFluentRegistry> registrationAction = null) {
            if (Interlocked.CompareExchange(ref locked, 1, 0) == 0) {
                if (registrationAction.IsNotNull()) {
                    registrationAction(registry);
                }

                ConfigureInternal();
            }
        }
    }
}
