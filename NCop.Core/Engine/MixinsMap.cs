using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using NCop.Core.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Core.Engine
{
    public class MixinsMap : IMixinsMap
    {
        private ISet<Type> _immediateInterfaces = null;
        private ISet<Type> _registered = new HashSet<Type>();
        private List<MixinMap> _map = new List<MixinMap>();

        public MixinsMap(Type type) {
            _immediateInterfaces = type.GetImmediateInterfaces().ToSet();
            _map.AddRange(FindMixinsRecursively(type));

            if (_map.Count != _immediateInterfaces.Count) {
                var missing = _immediateInterfaces.Except(_map.Select(map => map.Contract));

                throw new MissingMixinException(missing.First().Name);
            }
        }

        private IEnumerable<MixinMap> FindMixinsRecursively(Type type) {
            var mixins = FindMixins(type);

            if (_immediateInterfaces.Count != _registered.Count) {
                var interfaces = type.GetImmediateInterfaces();
                var leftToFind = interfaces.Except(_registered);

                mixins = mixins.Concat(leftToFind.SelectMany(@interface => {
                    return FindMixinsRecursively(@interface);
                }));
            }

            return mixins;
        }

        private IEnumerable<MixinMap> FindMixins(Type type) {
            var mixinsMap = new List<MixinMap>();
            var mixinsAtribute = type.GetCustomAttribute<MixinsAttribute>();

            if (mixinsAtribute != null) {
                mixinsAtribute.Mixins.ForEach(mixin => {
                    mixin.GetImmediateInterfaces()
                         .ForEach(@interface => {
                             if (_immediateInterfaces.Contains(@interface)) {
                                 var mixinMap = new MixinMap(@interface, mixin);

                                 if (!_registered.Add(@interface)) {
                                     throw new DuplicateMixinAnnotationException(@interface.FullName);
                                 }

                                 mixinsMap.Add(mixinMap);
                             }
                         });
                });
            }

            return mixinsMap.NullCoalesce();
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
