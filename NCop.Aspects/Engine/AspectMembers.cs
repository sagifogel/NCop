using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
	public class AspectBag : IAspectMembers<MemberInfo>
	{
		public AspectBag(MemberInfo target,  IEnumerable<MemberInfo> members) {
			Target = target;
			Members = members;
		}

		public MemberInfo Target { get; private set; }
		public IEnumerable<MemberInfo> Members { get; private set; }
	}
}
