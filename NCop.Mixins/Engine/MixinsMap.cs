using NCop.Core;
using NCop.Core.Exceptions;
using NCop.Mixins.Exceptions;
using NCop.Mixins.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Mixins.Engine
{
    public class MixinsMap : ITypeMapCollection
    {
        private readonly List<TypeMap> map = null;
        private AttributeTypeMatcher<MixinsAttribute> matcher = null;

        public MixinsMap(Type compositeType) {
            try {
                matcher = new AttributeTypeMatcher<MixinsAttribute>(compositeType, attr => attr.Mixins);
                map = new List<TypeMap>(
                    matcher.Select(tuple => {
                        return TypeMap.Create(tuple.Item1, tuple.Item2);
                    })
                );
            }
            catch (MissingTypeException missingTypeException) {
                throw new MissingMixinException(missingTypeException);
            }
            catch (DuplicateTypeAnnotationException duplicateTypeAnnotationException) {
                throw new DuplicateMixinAnnotationException(duplicateTypeAnnotationException);
            }
            catch (TypeDefinitionInitializationException typeDefinitionInitializationException) {
                throw new MixinAnnotationException(typeDefinitionInitializationException);
            }
        }

        public Type compositeType { get; private set; }

        public MixinsMap(IEnumerable<TypeMap> mixinsMap) {
            map = mixinsMap.ToList();
        }

        public int Count {
            get {
                return map.Count;
            }
        }

        public IEnumerator<TypeMap> GetEnumerator() {
            return map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
