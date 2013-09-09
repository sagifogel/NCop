using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using NCop.Core;
using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NCop.Aspects.Engine;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
	public class AspectsMap : IAspectsMap
	{
		private List<AspectMap> map = null;
		private AspectAttributeTypeMatcher matcher = null;

		public AspectsMap(Type compositeType, IAspectMemebrsCollection aspectMembers) {
			try {
				matcher = new AspectAttributeTypeMatcher(compositeType, aspectMembers);
				map = new List<AspectMap>(matcher.Select(tuple => new AspectMap(tuple.Item1, tuple.Item2)));
				EnsureValidAspects(map);
			}
			catch (MissingTypeException missingTypeException) {
				throw new MissingAspectException(missingTypeException);
			}
		}

		private static void EnsureValidAspects(IEnumerable<AspectMap> aspectsMap) {
			aspectsMap.ForEach(aspects => {
				aspects.Aspects.ForEach(aspect => {
					if (!KnownAspects.IsAspect(aspect)) {
						throw new MissingAspectException(aspect.AspectType.FullName);
					}
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
