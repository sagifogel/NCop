using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;
using System.Threading;
using NCop.IoC.Fluent;
using NCop.Core;

namespace NCop.IoC
{
	public class NCopContainer : AbstractContainer
	{
		private readonly NCopContainer parentContainer = null;
		private Stack<NCopContainer> childContainers = new Stack<NCopContainer>();

		public NCopContainer(Action<IRegistry> registrationAction)
			: this(registrationAction, null) {
		}

		internal NCopContainer(Action<IRegistry> registrationAction, NCopContainer parentContainer)
			: base(registrationAction) {
			this.parentContainer = parentContainer;
		}

		protected override ServiceEntry GetEntry(ServiceKey key) {
			ServiceEntry entry = base.GetEntry(key);

			if (entry.IsNull()) {
				parentContainer.TryGetEntryWhenNotNull(key, out entry);
			}

			return entry;
		}

		public INCopContainer CreateChildContainer(Action<IRegistry> registrationAction) {
			NCopContainer container = null;

			lock (childContainers) {
				childContainers.Push(container = new NCopContainer(registrationAction, this));
			}

			return container;
		}

		public void Dispose() {
			base.Dispose();

			lock (childContainers) {
				while (childContainers.Count > 0) {
					childContainers.Pop().Dispose();
				}
			}
		}
	}
}