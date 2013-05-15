using NCop.Core.Extensions;
using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NCop.IoC
{
    public class NCopContainer : AbstractContainer, IContainerConfigurator<INCopContainer>
    {
        private int locked = 0;
        private readonly NCopContainer parentContainer = null;
        private Stack<NCopContainer> childContainers = new Stack<NCopContainer>();

        public NCopContainer(Action<IFluentRegistry> registrationAction = null)
            : this(registrationAction, null) {
        }

        internal NCopContainer(Action<IFluentRegistry> registrationAction, NCopContainer parentContainer) {
            this.parentContainer = parentContainer;

            if (registrationAction.IsNotNull()) {
                Configure(registrationAction);
            }
        }

        public INCopContainer Configure(Action<IFluentRegistry> registrationAction = null) {
            if (Interlocked.CompareExchange(ref locked, 1, 0) == 0) {
                base.ConfigureInternal(registrationAction);
            }

            return this;
        }

        protected override ServiceEntry GetEntry(ServiceKey key) {
            ServiceEntry entry = base.GetEntry(key);

            if (entry.IsNull() && parentContainer.IsNotNull()) {
                parentContainer.TryGetEntry(key, out entry);
            }

            return entry;
        }

        public INCopContainer CreateChildContainer(Action<IFluentRegistry> registrationAction = null) {
            NCopContainer container = null;

            lock (childContainers) {
                childContainers.Push(container = new NCopContainer(registrationAction, this));
            }

            return container;
        }

        public override void Dispose() {
            base.Dispose();

            lock (childContainers) {
                while (childContainers.Count > 0) {
                    childContainers.Pop().Dispose();
                }
            }
        }
    }
}