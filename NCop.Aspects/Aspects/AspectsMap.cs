using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using NCop.Core;
using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace NCop.Aspects.Aspects
{
    public class AspectsMap : IAspectsMap
    {
        private List<AspectMap> _map = null;
        private AspectsAttributeTypeMatcher _matcher = null;

        public AspectsMap(Type type) {
            try {
                _matcher = new AspectsAttributeTypeMatcher(type);
                _map = new List<AspectMap>(_matcher.Select(tuple => new AspectMap(tuple.Item1, tuple.Item2)));
                EnsureValidAspects(_map);
            }
            catch (MissingTypeException missingTypeException) {
                throw new MissingAspectException(missingTypeException);
            }
        }

        private static void EnsureValidAspects(IEnumerable<AspectMap> aspectsMap) {
            aspectsMap.ForEach(aspects => {
                aspects.AspectTypes.ForEach(aspect => {
                    if (!IsAspect(aspect)) {
                        throw new MissingAspectException(aspects.Contract.FullName);
                    }
                });
            });
        }

        private static bool IsAspect(Type aspectType) {
            return typeof(TypeLevelAspect).IsAssignableFrom(aspectType) ||
                   aspectType.GetInterfaces()
                             .Any(@interface => @interface.Equals(typeof(IAspectFilter)));
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
