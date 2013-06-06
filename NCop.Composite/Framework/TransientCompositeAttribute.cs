using NCop.Composite.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Framework
{
	public class TransientCompositeAttribute : CompositeAttribute
	{
		public TransientCompositeAttribute(Type castAs = null)
			: base(castAs) {

		}
	}
}
