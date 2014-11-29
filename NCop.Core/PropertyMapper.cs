using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Core
{
	public class PropertyMapper : IPropertyMapper
	{
		private readonly List<IPropertyMap> mappedProperties = null;

		public PropertyMapper(ITypeMap mixinsMap) {
			var mapped = mixinsMap.Select(mixin => new {
				mixin.ContractType,
				mixin.ImplementationType,
				ContractProperties = mixin.ContractType.GetProperties(),
				ImplProperties = mixin.ImplementationType.GetProperties().ToSet()
			});

			var mappedPropertiesEnumerable = mapped.SelectMany(map => {
				var properties = map.ContractProperties;

				return properties.Select(property => {
					var match = property.SelectFirst(map.ImplProperties,
													 (c, impl) => c.IsMatchedTo(impl),
													 (c, impl) => new {
														 ImplProperty = impl,
														 ContractProperty = c
													 });

					return new PropertyMap(map.ContractType,
										   map.ImplementationType,
										   match.ContractProperty,
                                           match.ImplProperty);
				});
			});

			mappedProperties = mappedPropertiesEnumerable.Cast<IPropertyMap>()
														 .ToList();
		}

		public IEnumerator<IPropertyMap> GetEnumerator() {
			return mappedProperties.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public int Count {
			get {
				return mappedProperties.Count;
			}
		}
	}
}
