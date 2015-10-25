using NCop.Core.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Core
{
	public class PropertyMapper : IPropertyMapper
	{
		private readonly List<IPropertyMap> mappedProperties = null;

		public PropertyMapper(ITypeMapCollection mixinsMap) {
			var mapped = mixinsMap.Select(mixin => new {
				ServiceType = mixin.ServiceType,
				ConcreteType = mixin.ConcreteType,
				ContractProperties = mixin.ServiceType.GetProperties(),
				PropertiesImpl = mixin.ConcreteType.GetProperties().ToSet()
			});

			var mappedPropertiesEnumerable = mapped.SelectMany(map => {
				var properties = map.ContractProperties;

				return properties.Select(property => {
                    var match = property.SelectFirst(map.PropertiesImpl,
													 (c, impl) => c.IsMatchedTo(impl),
													 (c, impl) => new {
														 ServiceProperty = c,
                                                         ConcreteProperty = impl
													 });

                    return new PropertyMap(map.ServiceType,
                                           map.ConcreteType,
                                           match.ServiceProperty,
                                           match.ConcreteProperty);
				});
			});

			mappedProperties = mappedPropertiesEnumerable.ToListOf<IPropertyMap>();
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
