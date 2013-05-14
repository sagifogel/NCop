using NCop.Core;
using NCop.Core.Exceptions;
using NCop.Core.Mixin;
using NCop.Mixins.Exceptions;
using NCop.Mixins.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Mixins.Engine
{
    public class MixinsMap : IMixinsMap
    {
        private readonly List<MixinMap> map = null;
        private AttributeTypeMatcher<MixinsAttribute> matcher = null;

        public MixinsMap(Type compositeType) {
            try {
                CompositeType = compositeType;
                matcher = new AttributeTypeMatcher<MixinsAttribute>(compositeType, (attr) => attr.Mixins);
                map = new List<MixinMap>(
                    matcher.Select(tuple => {
                        return new MixinMap(tuple.Item1, tuple.Item2);
                    })
                );
            }
            catch (MissingTypeException missingTypeException) {
                throw new MissingMixinException(missingTypeException);
            }
            catch (DuplicateTypeAnnotationException duplicateTypeAnnotationException) {
                throw new DuplicateMixinAnnotationException(duplicateTypeAnnotationException);
            }
        }

        public Type CompositeType { get; private set; }

        public MixinsMap(IEnumerable<MixinMap> mixinsMap) {
            map = mixinsMap.ToList();
        }

        public int Count {
            get {
                return map.Count;
            }
        }

        public IEnumerator<MixinMap> GetEnumerator() {
            return map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
