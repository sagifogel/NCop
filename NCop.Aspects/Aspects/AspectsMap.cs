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
using NCop.Core.Engine;

namespace NCop.Aspects.Aspects
{
	public class AspectsMap : IAspectsMap
	{
		private List<AspectMap> _map = null;
		private AspectAttributeTypeMatcher _matcher = null;

		public AspectsMap(Type compositeType, IGroupedMethodsCollection groupedMethods) {
			try {
				_matcher = new AspectAttributeTypeMatcher(compositeType, groupedMethods);
				//_map = new List<AspectMap>(_matcher.Select(tuple => new AspectMap(tuple.Item1, tuple.Item2)));
				EnsureValidAspects(_map);
			}
			catch (MissingTypeException missingTypeException) {
				throw new MissingAspectException(missingTypeException);
			}
		}

		private static void EnsureValidAspects(IEnumerable<AspectMap> aspectsMap) {
			aspectsMap.ForEach(aspects => {
				aspects.AspectTypes.ForEach(aspect => {
					if (!KnownAspects.IsAspect(aspect)) {
						throw new MissingAspectException(aspects.ContractType.FullName);
					}
				});
			});
		}

		public int Count {
			get {
				return _map.Count;
			}
		}

		public IEnumerator<AspectMap> GetEnumerator() {
			return _map.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
