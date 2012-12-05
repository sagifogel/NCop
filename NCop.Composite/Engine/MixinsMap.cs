using NCop.Core.Exceptions;
using NCop.Core.Extensions;
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
        private List<MixinMap> _map = null;
        private TypeMatcher<MixinsAttribute> _matcher = null;

        public MixinsMap(Type type) {
            try {
                _matcher = new TypeMatcher<MixinsAttribute>(type, (attr) => attr.Mixins);
                _map = new List<MixinMap>(
                    _matcher.Select(tuple => {
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

        public int Count {
            get {
                return _map.Count;
            }
        }

        public IEnumerator<MixinMap> GetEnumerator() {
            return _map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
