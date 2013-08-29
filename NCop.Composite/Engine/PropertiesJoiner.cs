using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;
using System.Collections;
using NCop.Core.Engine;

namespace NCop.Composite.Engine
{
	internal class PropertiesJoiner : Tuples<PropertyInfo, Type, Type>
	{
		internal PropertiesJoiner(IMixinsMap mixinsMap) {
			var joined = mixinsMap.Select(mixin => new {
				ContractType = mixin.ContractType,
				ImplementationType = mixin.ImplementationType,
				ContractProperties = mixin.ContractType.GetProperties(),
				ImplProperties = mixin.ImplementationType.GetProperties().ToSet()
			});

			Values = joined.SelectMany(join => {
				var properties = join.ContractProperties;

				return properties.Select(property => {
					var result = property.SelectFirst(join.ImplProperties,
													 (c, impl) => PropertyMatch(c, impl),
													 (c, impl) => impl);

					return Tuple.Create(result, join.ImplementationType, join.ContractType);
				});
			});
		}

		protected static bool PropertyMatch(PropertyInfo firstProperty, PropertyInfo secondProperty) {
			if (!firstProperty.Name.Equals(secondProperty.Name) || !AccessModifierMatch(firstProperty, secondProperty)) {
				return false;
			}

			return firstProperty.PropertyType.Equals(secondProperty.PropertyType) ||
					TypeComparer.Compare(firstProperty.PropertyType, secondProperty.PropertyType);
		}

		protected static bool AccessModifierMatch(PropertyInfo firstProperty, PropertyInfo secondProperty) {
			if (firstProperty.CanRead && !secondProperty.CanRead || !firstProperty.CanRead && secondProperty.CanRead ||
				firstProperty.CanWrite && !secondProperty.CanWrite || firstProperty.CanRead && !secondProperty.CanWrite) {
				return false;
			}

			return true;
		}
	}
}
