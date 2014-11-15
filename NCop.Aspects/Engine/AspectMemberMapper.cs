using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Aspects.Engine;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class AspectMemberMapper : IAspectMemebrsCollection
    {
        private List<IAspectMethodMap> mappedMethods = null;
        private List<IAspectPropertyMap> mappedProperties = null;

        public AspectMemberMapper(Type aspectDeclaringType, ITypeMap typeMap) {
            MapMethods(aspectDeclaringType, typeMap);
            MapProperties(aspectDeclaringType, typeMap);
        }

        private void MapMethods(Type aspectDeclaringType, ITypeMap typeMap) {
            var methods = aspectDeclaringType.GetMethods();
            var methodMapper = new MethodMapper(typeMap);

            var mappedMethodsEnumerable = methodMapper.Select(map => {
                var aspectMethod = methods.FirstOrDefault(method => {
                    return method.IsMatchedTo(map.ContractMember);
                });

                return new AspectMethodMap(map.ContractType,
                                           map.ImplementationType,
                                           map.ContractMember,
                                           map.ImplementationMember,
                                           aspectMethod);
            });

            mappedMethods = mappedMethodsEnumerable.ToList<IAspectMethodMap>();
        }

        private void MapProperties(Type aspectDeclaringType, ITypeMap typeMap) {
            var properties = aspectDeclaringType.GetProperties();
            var propertyMapper = new PropertyMapper(typeMap);

            var mappedPropertiesEnumerable = propertyMapper.Select(map => {
                var aspectProperty = properties.FirstOrDefault(property => {
                    return property.IsMatchedTo(map.ContractMember);
                });

                return new AspectPropertyMap(map.ContractType,
                                             map.ImplementationType,
                                             map.ContractMember,
                                             map.ImplementationMember,
                                             aspectProperty);
            });

            mappedProperties = mappedPropertiesEnumerable.ToList<IAspectPropertyMap>();
        }

        public IEnumerable<IAspectMethodMap> Methods {
            get {
                return mappedMethods;
            }
        }

        public IEnumerable<IAspectPropertyMap> Properties {
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
            var aspectsProperties = mappedProperties.Cast<IAspectMembers<MemberInfo>>();

            return mappedMethods.Concat(aspectsProperties).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}