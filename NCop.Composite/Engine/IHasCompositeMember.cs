using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Engine
{
	public interface IHasCompositeMember<TMemebr>
		where TMemebr : MemberInfo
	{
		TMemebr CompositeMember { get; }
	}
}
