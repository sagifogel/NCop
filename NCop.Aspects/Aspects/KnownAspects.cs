using NCop.Aspects.Aspects.Builders;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public static class KnownAspects
    {
        private static ISet<IAspectBuilderProvider> _knownProviders = null;

        static KnownAspects() {
            _knownProviders = new HashSet<IAspectBuilderProvider>(
                new IAspectBuilderProvider[]{
                        new AttributeAspectBuilderProvider(),
                        new TypeLevelAspectBuilderProvider()
                }
            );
        }

        public static void RegisterKnownBuilder(IAspectBuilderProvider provider) {
            _knownProviders.Add(provider);
        }

        public static bool IsAspect(Type type) {
            return GetAspectProvider(type) != null;
        }

        public static IAspectBuilder MatchAspectBuilder(Type type) {
            var matchedProvider = GetAspectProvider(type);

            if (matchedProvider == null) {
                throw new AspectBuilderNotFoundException(type);
            }

            return matchedProvider.Builder;
        }

        public static IAspectBuilderProvider GetAspectProvider(Type type) {
            return _knownProviders.FirstOrDefault(provider => provider.CanBuild(type));
        }
    }
}