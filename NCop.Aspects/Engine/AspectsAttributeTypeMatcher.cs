using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Core;
using NCop.Core.Extensions;

namespace NCop.Aspects.Engine
{
	public class AspectAttributeTypeMatcher : Tuples<MemberInfo, IEnumerable<IAspect>>
	{
		public AspectAttributeTypeMatcher(Type compositeType, IAspectMemebrsCollection aspectMembers) {
			Values = aspectMembers.Select(aspect => {
				var aspects = aspect.Members.SelectMany(method => {
					return method.GetCustomAttributes<IAspect>();
				});

				return Tuple.Create(aspect.Target, aspects);
			});
		}
	}
}
