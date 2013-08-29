using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Core;
using NCop.Core.Engine;
using NCop.Core.Extensions;

namespace NCop.Aspects.Engine
{
	public class AspectAttributeTypeMatcher : Tuples<Type, IEnumerable<MemberInfo>>
	{
		//private Dictionary<Type, Tuple<MemberInfo, IEnumerable<IAspect>>> registered = null;

		public AspectAttributeTypeMatcher(Type compositeType, IGroupedMethodsCollection groupedMethods) {
			AspectAttribute attribute = null;

			//registered = new ConcurrentDictionary<Type, Tuple<MemberInfo, IEnumerable<IAspect>>>();
			attribute = compositeType.GetCustomAttribute<AspectAttribute>();

			if (attribute.IsNotNull()) {
				return;
			}

			groupedMethods.ForEach(group => {
			});
		}
	}
}
