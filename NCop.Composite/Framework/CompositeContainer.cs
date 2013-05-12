using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;
using NCop.IoC.Fluent;

namespace NCop.Composite.Framework
{
	public class CompositeContainer : AbstractContainer
	{
		private readonly INCopContainer container = null;

		public CompositeContainer(Action<IRegistry> registrationAction)
			: base(registrationAction) {
		}
	}
}
