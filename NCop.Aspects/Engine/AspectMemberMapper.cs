using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class AspectMemberMapper : IAspectMemebrsCollection
    {
        private List<IAspectEventMap> mappedEvents = null;
        private List<IAspectMethodMap> mappedMethods = null;
        private List<IAspectPropertyMap> mappedProperties = null;

        public AspectMemberMapper(Type aspectDeclaringType, ITypeMap typeMap) {
            MapEvents(aspectDeclaringType, typeMap);
            MapMethods(aspectDeclaringType, typeMap);
            MapProperties(aspectDeclaringType, typeMap);
        }

        private void MapEvents(Type aspectDeclaringType, ITypeMap typeMap) {
            var events = aspectDeclaringType.GetPublicEvents();
            var eventMapper = new EventMapper(typeMap);

            var mappedEventsEnumerable = eventMapper.Select(map => {
                var aspectEvent = events.FirstOrDefault(@event => {
                    return @event.EventHandlerType.Equals(map.ContractMember.EventHandlerType) &&
                           @event.GetAddMethod().IsMatchedTo(map.ContractMember.GetAddMethod());
                });

                return new AspectEventMap(map.ContractType,
                                          map.ImplementationType,
                                          map.ContractMember,
                                          map.ImplementationMember,
                                          aspectEvent);
            });

            mappedEvents = mappedEventsEnumerable.ToList<IAspectEventMap>();
        }

        private void MapMethods(Type aspectDeclaringType, ITypeMap typeMap) {
            var methods = aspectDeclaringType.GetPublicMethods();
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
            var properties = aspectDeclaringType.GetPublicProperties();
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

        public IEnumerable<IAspectEventMap> Events {
            get {
                return mappedEvents;
            }
        }

        public int Count {
            get {
                return mappedMethods.Count +
                       mappedProperties.Count +
                       mappedEvents.Count;
            }
        }

        public IEnumerator<IAspectMembers<MemberInfo>> GetEnumerator() {
            var aspectEvents = mappedEvents.Cast<IAspectMembers<MemberInfo>>();
            var aspectsProperties = mappedProperties.Cast<IAspectMembers<MemberInfo>>();

            return mappedMethods.Concat(aspectsProperties).Concat(aspectEvents).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}