using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace NCop.Composite.Engine
{
    public class AspectsMap : IAspectsMap
    {
        private List<AspectMap> _map = null;
        private TypeMatcher<AspectsAttribute> _matcher = null;

        public AspectsMap(Type type) {
            try {
                _matcher = new TypeMatcher<AspectsAttribute>(type, (attr) => attr.Aspects);
                _map = new List<AspectMap>(_matcher.Select(tuple => {
                    return new AspectMap(tuple.Item1, tuple.Item2);
                }));

                EnsureValidAspects(_map);
            }
            catch (MissingTypeException missingTypeException) {
                throw new MissingAspectException(missingTypeException);
            }
            catch (DuplicateTypeAnnotationException duplicateTypeAnnotationException) {
                throw new DuplicateAspectException(duplicateTypeAnnotationException);
            }
        }

        private static void EnsureValidAspects(IEnumerable<AspectMap> aspectsMap) {
            aspectsMap.ForEach(aspect => {
                if (!IsAspect(aspect.AspectType)) {
                    //throw new MissingAspectException(aspect.Contract.FullName);
                }
            });
        }

        private static bool IsAspect(Type aspectType) {
            var baseType = aspectType.BaseType;

            if (baseType != null) {
                var genericImpl = baseType.GetGenericTypeDefinition();

                return genericImpl != null && genericImpl.Equals(typeof(AspectOf<>));
            }

            return aspectType.GetInterfaces()
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
