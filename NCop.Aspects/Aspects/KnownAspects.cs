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
		private static ISet<IAspectBuilderProvider> knownProviders = null;

		static KnownAspects() {
			knownProviders = new HashSet<IAspectBuilderProvider>(
				new IAspectBuilderProvider[]{
                        new AttributeAspectBuilderProvider(),
                        new TypeLevelAspectBuilderProvider()
                });
		}

		public static void RegisterKnownBuilder(IAspectBuilderProvider provider) {
			knownProviders.Add(provider);
		}

		public static bool IsAspect(IAspect aspect) {
			Func<IAspectBuilderProvider, bool> canBuildFrom = builder => {
				return builder.CanBuildAspectFromType(aspect.GetType());
			};

			return knownProviders.Any(canBuildFrom);
		}

		public static bool TryMatchAspectBuilder(MemberInfo memberInfo, out IAspectBuilder builder) {
			var matchedProvider = GetAspectProvider(memberInfo);

			builder = null;

			if (matchedProvider != null) {
				builder = matchedProvider.GetBuilder(memberInfo);
			}

			return builder != null;
		}

		private static IAspectBuilderProvider GetAspectProvider(MemberInfo memberInfo) {
			return knownProviders.FirstOrDefault(provider => provider.CanBuild(memberInfo));
		}
	}
}