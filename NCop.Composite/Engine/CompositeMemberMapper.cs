using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Aspects.Engine;
using System.Reflection;

namespace NCop.Composite.Engine
{
	public class CompositeMemberMapper : IAspectMemebrsCollection
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

			mappedMethods = mappedMethodsEnumerable.ToListOf<ICompositeMethodMap>();
		}

		private void MapProperties(Type compositeType, ITypeMap mixinsMap) {
			var compositeProperties = compositeType.GetProperties();
			var propertyMapper = new PropertyMapper(mixinsMap);

			var mappedPropertiesEnumerable = propertyMapper.Select(map => {
				var compositeMethod = compositeProperties.FirstOrDefault(m => {
					return m.IsMatchedTo(map.ContractMember);
				});

				return new CompositePropertyMap(map.ContractType,
												map.ImplementationType,
												compositeMethod,
												map.ImplementationMember,
												map.ContractMember);
			});

			mappedProperties = mappedPropertiesEnumerable.ToListOf<ICompositePropertyMap>();
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

		public int Count {
			get {
				return mappedMethods.Count + mappedProperties.Count;
			}
		}

		public IEnumerator<IAspectMembers<MemberInfo>> GetEnumerator() {
			var aspectsMethods = mappedMethods.Cast<IAspectMembers<MemberInfo>>();
			var aspectsProperties = mappedProperties.Cast<IAspectMembers<MemberInfo>>();

			return aspectsMethods.Concat(aspectsProperties).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}