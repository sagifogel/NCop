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

        private void MapEvents(IAspectsMap aspectsMap, IEnumerable<IAspectEventMap> aspectMappedEvents) {
            var mappedEventsList = aspectMappedEvents.ToList();

            var mappedFragmentEvents = MapEvents(aspectsMap, mappedEventsList, mapped => mapped.AspectAddEvent, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new CompositeAddEventMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            });

            mappedFragmentEvents = mappedFragmentEvents.Concat(MapRaiseEvents(aspectsMap, mappedEventsList));

            mappedFragmentEvents = mappedFragmentEvents.Concat(MapEvents(aspectsMap, mappedEventsList, mapped => mapped.AspectRemoveEvent, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new CompositeRemoveEventMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            }));

            mappedEvents = mappedFragmentEvents.Where(compositefragment => compositefragment.FragmentMethod.IsNotNull())
                                               .ToGroupedDictionary(map => map.Target)
                                               .ToList(keyValue => new CompositeEventMap(keyValue.Value) as ICompositeEventMap);
        }

        private IEnumerable<ICompositeEventFragmentMap> MapEvents(IEnumerable<AspectMap> aspectsMap, IEnumerable<IAspectEventMap> aspectMappedEvents, Func<IAspectEventMap, MethodInfo> eventyFactory, Func<Type, Type, EventInfo, EventInfo, IAspectDefinitionCollection, ICompositeEventFragmentMap> compositeEventMapFactory) {
            return from mapped in aspectMappedEvents
                   from aspectMap in aspectsMap.Where(map => {
                       var method = map.Method as MethodInfo;

                       return method.IsMatchedTo(eventyFactory(mapped));
                   })
                   .DefaultIfEmpty(AspectMap.Empty)
                   select compositeEventMapFactory(mapped.ContractType,
                                                   mapped.ImplementationType,
                                                   mapped.ContractMember,
                                                   mapped.ImplementationMember,
                                                   aspectMap.Aspects);
        }

        private IEnumerable<ICompositeEventFragmentMap> MapRaiseEvents(IEnumerable<AspectMap> aspectsMap, IEnumerable<IAspectEventMap> aspectMappedEvents) {
            var invokeAspets = aspectsMap.Where(aspectMap => aspectMap.Aspects.All(aspect => aspect is RaiseEventFragmentInterceptionAspectDefinition));

            return invokeAspets.Join(aspectMappedEvents, inner => {
                var aspect = inner.Aspects.FirstOrDefault() as RaiseEventFragmentInterceptionAspectDefinition;

                return aspect.IsNotNull() ? new EventComparer(aspect.Member) : null;
            },
            outer => new EventComparer(outer.Target),
            (outer, inner) => new CompositeRaiseEventMap(inner.ContractType,
                                                         inner.ImplementationType,
                                                         inner.ContractMember,
                                                         inner.ImplementationMember,
                                                         outer.Aspects));
        }

        private void MapMethods(IAspectsMap aspectsMap, IEnumerable<IAspectMethodMap> aspectMappedMethods) {
            var mappedMethodsEnumerable = from mapped in aspectMappedMethods
                                          from aspectMap in aspectsMap.Where(map => {
                                              var method = map.Method as MethodInfo;

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
            var mappedPropertiesList = aspectMappedProperties.ToList();

            var mappedFragmentProperties = MapProperties(aspectsMap, mappedPropertiesList, mapped => mapped.AspectGetProperty, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new CompositeGetPropertyMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            });

            mappedFragmentProperties = mappedFragmentProperties.Concat(MapProperties(aspectsMap, mappedPropertiesList, mapped => mapped.AspectSetProperty, (contractType, implementationType, contractMember, implementationMember, aspectMap) => {
                return new CompositeSetPropertyMap(contractType, implementationType, contractMember, implementationMember, aspectMap);
            }));

            mappedProperties = mappedFragmentProperties.Where(compositefragment => compositefragment.FragmentMethod.IsNotNull())
                                                       .ToGroupedDictionary(map => map.Target)
                                                       .ToList(keyValue => new CompositePropertyMap(keyValue.Value) as ICompositePropertyMap);
        }

        private IEnumerable<ICompositePropertyFragmentMap> MapProperties(IEnumerable<AspectMap> aspectsMap, IEnumerable<IAspectPropertyMap> aspectMappedProperties, Func<IAspectPropertyMap, MethodInfo> propertyFactory, Func<Type, Type, PropertyInfo, PropertyInfo, IAspectDefinitionCollection, ICompositePropertyFragmentMap> compositePropertyMapFactory) {
            return from mapped in aspectMappedProperties
                   from aspectMap in aspectsMap.Where(map => {
                       var method = map.Method as MethodInfo;

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
