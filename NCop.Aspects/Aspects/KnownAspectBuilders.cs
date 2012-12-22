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
    public static class KnownAspectBuilders
    {
        private static ISet<IAspectBuilderProvider> _knownProviders = null;

        static KnownAspectBuilders() {
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

        public static IAspectBuilder MatchAspectBuilder(Type type) {
            var matchedProvider = _knownProviders.FirstOrDefault(provider => provider.CanBuild(type));

            if (matchedProvider == null) {
                throw new AspectBuilderNotFoundException(type);
            }

            return matchedProvider.Builder;
        }
    }
}
