using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Aspects
{
	public class AspectMap
	{
        public AspectMap(MemberInfo member, IAspectDefinitionCollection aspects) {
			Member = member;
			Aspects = aspects;
		}

		public MemberInfo Member { get; private set; }
		public IAspectDefinitionCollection Aspects { get; private set; }
	}
}
