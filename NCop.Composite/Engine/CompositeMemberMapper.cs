using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Aspects.Engine;
using System.Reflection;
using NCop.Aspects.Aspects;

namespace NCop.Composite.Engine
{
    public class CompositeMemberMapper : IAspectMemebrsCollection
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
                                              var method = map.Member as MethodInfo;

                                              return method.IsMatchedTo(mapped.ImplementationMember);
                                          }).DefaultIfEmpty()
                                          select new CompositeMethodMap(mapped.ContractType,
                                                                        mapped.ImplementationType,
                                                                        mapped.ContractMember,
                                                                        mapped.ImplementationMember,
                                                                        aspectMap.Aspects);

            mappedMethods = mappedMethodsEnumerable.ToListOf<ICompositeMethodMap>();
        }

        private void MapProperties(IAspectsMap aspectsMap, IEnumerable<IAspectPropertyMap> aspectMappedProperties) {
            var mappedPropertiesEnumerable = from mapped in aspectMappedProperties
                                             from aspectMap in aspectsMap.Where(map => {
                                                 var method = map.Member as PropertyInfo;

                                                 return method.IsMatchedTo(mapped.ImplementationMember);
                                             }).DefaultIfEmpty()
                                             select new CompositePropertyMap(mapped.ContractType,
                                                                             mapped.ImplementationType,
                                                                             mapped.ContractMember,
                                                                             mapped.ImplementationMember,
                                                                             aspectMap.Aspects);

            mappedProperties = mappedPropertiesEnumerable.ToListOf<ICompositePropertyMap>();
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
            var aspectsMethods = mappedMethods.Cast<IAspectMembers<MemberInfo>>();
            var aspectsProperties = mappedProperties.Cast<IAspectMembers<MemberInfo>>();

            return aspectsMethods.Concat(aspectsProperties).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
