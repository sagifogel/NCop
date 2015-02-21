using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core;

namespace NCop.Composite.Engine
{
	public interface ICompositePropertyMapper : IReadOnlyCollection<ICompositeGetPropertyMap>
	{
	}
}
