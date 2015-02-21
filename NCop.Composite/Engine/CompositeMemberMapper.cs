using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class CompositeMemberMapper : ICompositeMemberCollection
    {
        private List<ICompositeMethodMap> mappedMethods = null;
        private List<ICompositePropertyMap> mappedProperties = null;

        public CompositeMemberMapper(IAspectsMap aspectMap, IAspectMemebrsCollection aspectMembersCollection) {
            MapMethods(aspectMap, aspectMembersCollection.Methods);
            MapProperties(aspectMap, aspectMembersCollection.Properties);
        }

        private void MapMethods(IAspectsMap aspectsMap, IEnumerable<IAspectMethodMap> aspetMappedMethods) {
            var mappedMethodsEnumerable = from mapped in aspetMappedMethods
                                          from aspectMap in aspectsMap.Where(map => {
                                              if (map.Member.MemberType == MemberTypes.Method) {
                                                  var method = map.Member as MethodInfo;

                                                  return method.IsMatchedTo(mapped.ImplementationMember);
                                              }

                                              return false;
                                          }).DefaultIfEmpty()
                                          select new CompositeMethodMap(mapped.ContractType,
                                                                        mapped.ImplementationType,
                                                                        mapped.ContractMember,
                                                                        mapped.ImplementationMember,
                                                                        aspectMap.Aspects);

            mappedMethods = mappedMethodsEnumerable.ToListOf<ICompositeMethodMap>();
        }

        private void MapProperties(IAspectsMap aspectsMap, IEnumerable<IAspectPropertyMap> aspectMappedProperties) {
            var mappedGetProperties = MapProperties(aspectsMap, aspectMappedProperties, mapped => mapped.AspectGetProperty, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new GetCompositePropertyMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            });

            var mappedSetProperties = MapProperties(aspectsMap, aspectMappedProperties, mapped => mapped.AspectSetProperty, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new SetCompositePropertyMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            });

            mappedProperties = mappedSetProperties.Concat(mappedGetProperties)
                                                  .ToListOf<ICompositePropertyMap>();
        }

        private IEnumerable<ICompositePropertyMap> MapProperties(IAspectsMap aspectsMap, IEnumerable<IAspectPropertyMap> aspectMappedProperties, Func<IAspectPropertyMap, MethodInfo> propertyFactory, Func<Type, Type, PropertyInfo, PropertyInfo, IAspectDefinitionCollection, ICompositePropertyMap> compositePropertyMapFactory) {
            return from mapped in aspectMappedProperties
                   from aspectMap in aspectsMap.Where(map => {
                       if (map.Member.MemberType == MemberTypes.Method) {
                           var method = map.Member as MethodInfo;

                           return method.IsMatchedTo(propertyFactory(mapped));
                       }

                       return false;
                   }).DefaultIfEmpty()
                   select compositePropertyMapFactory(mapped.ContractType,
                                                      mapped.ImplementationType,
                                                      mapped.ContractMember,
                                                      mapped.ImplementationMember,
                                                      aspectMap.Aspects);
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
