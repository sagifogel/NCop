using NCop.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using NCop.Core.Exceptions;

namespace NCop.Core.Engine
{
    public class CompositeMetadata
    {
        private ISet<Type> _immediateInterfaces = null;

        public CompositeMetadata(Type compositeType) {
            Type = compositeType;
            Interfaces = compositeType.GetImmediateInterfaces();
            _immediateInterfaces = Interfaces.ToSet();
            MixinsMap = GetMixins();

            if (MixinsMap.Count != _immediateInterfaces.Count) {
                var missing = _immediateInterfaces.Except(MixinsMap.Select(map => map.Contract));
                
                throw new MissingMixinException(missing.First().Name);
            }

            Concerns = compositeType.GetCustomAttributes<ConcernAttribute>();
        }

        public Type Type { get; private set; }

        public IEnumerable<Type> Interfaces { get; private set; }

        public IMixinsMap MixinsMap { get; private set; }

        public IEnumerable<ConcernAttribute> Concerns { get; private set; }

        private IMixinsMap GetMixins() {
            var mixinsMap = new MixinsMap();
            var registered = new HashSet<Type>();

            return new MixinsMap(FindMixinsRecursively(Type, registered));
        }

        private IEnumerable<MixinMap> FindMixinsRecursively(Type type, HashSet<Type> registered) {
            var mixins = FindMixins(type, registered);

            if (_immediateInterfaces.Count != registered.Count) {
                var interfaces = type.GetImmediateInterfaces();
                var leftToFind = interfaces.Except(registered);

                mixins = mixins.Concat(leftToFind.SelectMany(@interface => {
                    return FindMixinsRecursively(@interface, registered);
                }));
            }

            return mixins;
        }

        private IEnumerable<MixinMap> FindMixins(Type type, HashSet<Type> registered) {
            var mixinsMap = new MixinsMap();
            var mixinsAtribute = type.GetCustomAttribute<MixinsAttribute>();

            if (mixinsAtribute != null) {
                mixinsAtribute.Mixins.ForEach(mixin => {
                    mixin.GetImmediateInterfaces()
                         .ForEach(@interface => {
                             if (_immediateInterfaces.Contains(@interface)) {
                                 var mixinMap = new MixinMap(@interface, mixin);

                                 if (!registered.Add(@interface)) {
                                     throw new DuplicateMixinAnnotationException(@interface.FullName);
                                 }

                                 mixinsMap.Add(mixinMap);
                             }
                         });
                });
            }

            return mixinsMap.NullCoalesce();
        }
    }
}
