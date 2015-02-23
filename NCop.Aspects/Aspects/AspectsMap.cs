using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
	public class AspectsMap : IAspectsMap
	{
		private readonly List<AspectMap> map = null;

		public AspectsMap(Type compositeType, IAspectMemebrsCollection aspectMembers) {
			var matcher = new AspectAttributesMemberMatcher(compositeType, aspectMembers);
			
            map = new List<AspectMap>(matcher.Select(tuple => new AspectMap(tuple.Item1, tuple.Item2)));
			EnsureValidAspects(map);
		}

		private static void EnsureValidAspects(IEnumerable<AspectMap> aspectsMap) {
			aspectsMap.ForEach(aspectMap => {
				aspectMap.Aspects.ForEach(aspectDefinition => {
					AspectValidator.ValidateAspect(aspectDefinition.Aspect, aspectMap.Method);
				});
			});
		}

		public int Count {
			get {
				return map.Count;
			}
		}

		public IEnumerator<AspectMap> GetEnumerator() {
			return map.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
