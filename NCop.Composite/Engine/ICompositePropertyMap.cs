using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Engine;
using NCop.Core;

namespace NCop.Composite.Engine
{
	public interface ICompositePropertyMap : IAspectMembers<PropertyInfo>, IMemberMap<PropertyInfo>, IHasCompositeMember<PropertyInfo>
	{
	}
}
