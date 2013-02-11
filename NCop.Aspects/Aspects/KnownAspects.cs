using NCop.Aspects.Aspects.Builders;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                });
        }

        public static void RegisterKnownBuilder(IAspectBuilderProvider provider) {
            _knownProviders.Add(provider);
        }

        public static bool IsAspect(Type aspectType) {
            return _knownProviders.Any(provider => provider.CanBuildAspectFromType(aspectType));
        }

        public static IAspectBuilder MatchAspectBuilder(MethodInfo methodInfo) {
            var matchedProvider = GetAspectProvider(methodInfo);

            if (matchedProvider == null) {
                throw new AspectBuilderNotFoundException(methodInfo.DeclaringType);
            }

            return matchedProvider.Builder;
        }

        public static IAspectBuilderProvider GetAspectProvider(MethodInfo methodInfo) {
            return _knownProviders.FirstOrDefault(provider => provider.CanBuild(methodInfo));
        }
    }
}