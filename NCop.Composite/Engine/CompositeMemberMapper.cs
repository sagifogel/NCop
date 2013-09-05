using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NCop.Core;
using NCop.Core.Extensions;

namespace NCop.Composite.Engine
{
	public class CompositeMemberMapper
	{
		private List<ICompositeMethodMap> mappedMethods = null;
		private List<ICompositePropertyMap> mappedProperties = null;

		public CompositeMemberMapper(Type compositeType, ITypeMap mixinsMap) {
			MapMethods(compositeType, mixinsMap);
			MapProperties(compositeType, mixinsMap);
		}

		private void MapMethods(Type compositeType, ITypeMap mixinsMap) {
			var compositeMethods = compositeType.GetMethods();
			var methodMapper = new MethodMapper(mixinsMap);

			var mappedMethodsEnumerable = methodMapper.Select(map => {
				var compositeMethod = compositeMethods.FirstOrDefault(m => {
					return m.IsMatchedTo(map.ContractMember);
				});

				return new CompositeMethodMap(map.ContractType,
											  map.ImplementationType,
											  compositeMethod,
											  map.ImplementationMember,
											  map.ContractMember);
			});

			mappedMethods = mappedMethodsEnumerable.Cast<ICompositeMethodMap>().ToList();
		}

		private void MapProperties(Type compositeType, ITypeMap mixinsMap) {
			var compositeProperties = compositeType.GetProperties();
			var propertyMapper = new PropertyMapper(mixinsMap);

			var mappedMethodsEnumerable = propertyMapper.Select(map => {
				var compositeMethod = compositeProperties.FirstOrDefault(m => {
					return m.IsMatchedTo(map.ContractMember);
				});

				return new CompositePropertyMap(map.ContractType,
												map.ImplementationType,
												compositeMethod,
												map.ImplementationMember,
												map.ContractMember);
			});

			mappedMethods = mappedMethodsEnumerable.Cast<ICompositeMethodMap>().ToList();
		}

		public IEnumerable<ICompositeMethodMap> Methods {
			get {
				return mappedMethods;
			}
		}

		public IEnumerable<ICompositePropertyMap> Properties {
			get {
				return mappedProperties;
			}
		}
	}
}