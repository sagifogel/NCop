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
        private List<ICompositeEventMap> mappedEvents = null;
        private List<ICompositeMethodMap> mappedMethods = null;
        private List<ICompositePropertyMap> mappedProperties = null;

        public CompositeMemberMapper(IAspectsMap aspectMap, IAspectMemebrsCollection aspectMembersCollection) {
            MapEvents(aspectMap, aspectMembersCollection.Events);
            MapMethods(aspectMap, aspectMembersCollection.Methods);
            MapProperties(aspectMap, aspectMembersCollection.Properties);
        }

        private void MapEvents(IAspectsMap aspectsMap, IEnumerable<IAspectEventMap> aspetMappedEvents) {
            var methodMap = aspectsMap.Where(map => map.Member.MemberType == MemberTypes.Event);

            var mappedEventsEnumerable = from mapped in aspetMappedEvents
                                         from aspectMap in aspectsMap.Where(map => {
                                             var @event = map.Member as EventInfo;

                                             return @event.IsMatchedTo(mapped.ImplementationMember);
                                         })
                                         .DefaultIfEmpty(AspectMap.Empty)
                                         select new CompositeEventMap(mapped.ContractType,
                                                                      mapped.ImplementationType,
                                                                      mapped.ContractMember,
                                                                      mapped.ImplementationMember,
                                                                      aspectMap.Aspects);

            mappedEvents = mappedEventsEnumerable.ToListOf<ICompositeEventMap>();
        }

        private void MapMethods(IAspectsMap aspectsMap, IEnumerable<IAspectMethodMap> aspetMappedMethods) {
            var methodMap = aspectsMap.Where(map => map.Member.MemberType == MemberTypes.Method);

            var mappedMethodsEnumerable = from mapped in aspetMappedMethods
                                          from aspectMap in aspectsMap.Where(map => {
                                              var method = map.Member as MethodInfo;

                                              return method.IsMatchedTo(mapped.ImplementationMember);
                                          })
                                          .DefaultIfEmpty(AspectMap.Empty)
                                          select new CompositeMethodMap(mapped.ContractType,
                                                                        mapped.ImplementationType,
                                                                        mapped.ContractMember,
                                                                        mapped.ImplementationMember,
                                                                        aspectMap.Aspects);

            mappedMethods = mappedMethodsEnumerable.ToListOf<ICompositeMethodMap>();
        }

        private void MapProperties(IAspectsMap aspectsMap, IEnumerable<IAspectPropertyMap> aspectMappedProperties) {
            var mappedFragmentProperties = MapProperties(aspectsMap, aspectMappedProperties, mapped => mapped.AspectGetProperty, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new GetCompositePropertyMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            });

            mappedFragmentProperties = mappedFragmentProperties.Concat(MapProperties(aspectsMap, aspectMappedProperties, mapped => mapped.AspectSetProperty, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new SetCompositePropertyMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            }));

            mappedProperties = mappedFragmentProperties.Where(compositefragment => compositefragment.FragmentMethod.IsNotNull())
                                                       .ToGroupedDictionary(map => map.Target)
                                                       .ToList(keyValue => new CompositePropertyMap(keyValue.Value) as ICompositePropertyMap);
        }

        private IEnumerable<ICompositePropertyFragmentMap> MapProperties(IAspectsMap aspectsMap, IEnumerable<IAspectPropertyMap> aspectMappedProperties, Func<IAspectPropertyMap, MethodInfo> propertyFactory, Func<Type, Type, PropertyInfo, PropertyInfo, IAspectDefinitionCollection, ICompositePropertyFragmentMap> compositePropertyMapFactory) {
            var methodMap = aspectsMap.Where(map => map.Member.MemberType == MemberTypes.Method);

            return from mapped in aspectMappedProperties
                   from aspectMap in aspectsMap.Where(map => {
                       var method = map.Member as MethodInfo;

                       return method.IsMatchedTo(propertyFactory(mapped));
                   })
                   .DefaultIfEmpty(AspectMap.Empty)
                   select compositePropertyMapFactory(mapped.ContractType,
                                                      mapped.ImplementationType,
                                                      mapped.ContractMember,
                                                      mapped.ImplementationMember,
                                                      aspectMap.Aspects);
        }

        public IEnumerable<ICompositeEventMap> Events {
            get {
                return mappedEvents;
            }
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
                return mappedMethods.Count + mappedProperties.Count + mappedEvents.Count;
            }
        }

        public IEnumerator<IAspectMembers<MemberInfo>> GetEnumerator() {
            var aspectEvents = mappedEvents.Cast<IAspectMembers<MemberInfo>>();
            var aspectsMethods = mappedMethods.Cast<IAspectMembers<MemberInfo>>();
            var aspectsProperties = mappedProperties.Cast<IAspectMembers<MemberInfo>>();

            return aspectsMethods.Concat(aspectsProperties)
                                 .Concat(aspectEvents)
                                 .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
