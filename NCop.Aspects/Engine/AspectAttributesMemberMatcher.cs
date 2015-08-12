using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class AspectAttributesMemberMatcher : IEnumerable<AspectMap>
    {
        private static readonly bool partial = true;
        private readonly ConcurrentDictionary<int, AspectMap> registry = null;

        public AspectAttributesMemberMatcher(IAspectMemebrsCollection aspectMembersCollection) {
            registry = new ConcurrentDictionary<int, AspectMap>();
            CollectEventsAspectDefinitions(aspectMembersCollection);
            CollectMethodsAspectDefinitions(aspectMembersCollection);
            CollectPropertiesAspectDefinitions(aspectMembersCollection);
        }

        private void CollectMethodsAspectDefinitions(IAspectMethodMapCollection aspectMembersCollection) {
            aspectMembersCollection.Methods.ForEach(aspectMembers => {
                var aspects = aspectMembers.Members.SelectMany(member => {
                    return CollectMethodsAspectDefinitions(member, aspectMembers.ContractType, aspectMembers.Target);
                });

                AddOrUpdate(aspectMembers.Target, aspectMembers.ContractMember, aspectMembers.Target, aspects.ToList());
            });
        }

        private void CollectEventsAspectDefinitions(IAspectEventMapCollection aspectMembersCollection) {
            aspectMembersCollection.Events.ForEach(aspectMembers => {
                aspectMembers.Members.ForEach(member => {
                    CollectEventsAspectDefinitions(member, aspectMembers.ContractType, aspectMembers.ContractMember);
                });
            });
        }

        private void CollectPropertiesAspectDefinitions(IAspectPropertyMapCollection aspectMembersCollection) {
            List<IAspectPropertyMap> properties = null;
            var groupedProperties = aspectMembersCollection.Properties.ToGroupedDictionary(map => map.IsPartial, group => group.ToList());

            if (groupedProperties.TryGetValue(partial, out properties)) {
                CollectPartialPropertyAspectDefinitionsByPropertyInterceptionAttribute(properties);
            }

            if (groupedProperties.TryGetValue(!partial, out properties)) {
                CollectFullPropertyAspectDefinitions(properties);
            }
        }

        private void AddOrUpdate(MemberInfo target, MemberInfo contract, MethodInfo method, ICollection<IAspectDefinition> aspects) {
            AddOrUpdate(method.GetHashCode(), target, contract, method, aspects);
        }

        private void AddOrUpdate(int hash, MemberInfo target, MemberInfo contract, MethodInfo method, ICollection<IAspectDefinition> aspects) {
            if (aspects.Count > 0) {
                var aspectCollectionTuple = registry.GetOrAdd(hash, new AspectMap(target, contract, method, new AspectDefinitionCollection()));

                aspectCollectionTuple.Aspects.AddRange(aspects);
            }
        }

        private IEnumerable<IAspectDefinition> CollectMethodsAspectDefinitions(MethodInfo method, Type aspectDeclaringType, MethodInfo target) {
            var onMethodBoundaryAspects = method.GetCustomAttributes<OnMethodBoundaryAspectAttribute>();
            var methodInterceptionAspects = method.GetCustomAttributes<MethodInterceptionAspectAttribute>();

            var onMethodBoundaryAspectDefinitions = onMethodBoundaryAspects.Select(aspect => {
                return new OnMethodBoundaryAspectDefinition(aspect, aspectDeclaringType, target);
            });

            var methodInterceptionAspectDefinitions = methodInterceptionAspects.Select(aspect => {
                return new MethodInterceptionAspectDefinition(aspect, aspectDeclaringType, target);
            });

            return methodInterceptionAspectDefinitions.Cast<IAspectDefinition>()
                                                      .Concat(onMethodBoundaryAspectDefinitions);
        }

        private void CollectEventsAspectDefinitions(EventInfo @event, Type aspectDeclaringType, EventInfo target) {
            var addMethod = target.GetAddMethod();
            var raiseMethod = target.GetInvokeMethod();
            var removeMethod = target.GetRemoveMethod();
            var raiseMethodHash = Guid.NewGuid().GetHashCode();
            var eventInterceptionAspect = @event.GetCustomAttributes<EventInterceptionAspectAttribute>();

            eventInterceptionAspect.ForEach(aspectAttribute => {
                var aspectDefinition = new EventInterceptionAspectDefinition(aspectAttribute, aspectAttribute.AspectType, target);
                var bindingTypeReflectorBuilder = new EventBindingTypeReflectorBuilder(aspectDefinition);

                var addEventAspect = new AddEventFragmentInterceptionAspect {
                    AspectType = aspectAttribute.AspectType,
                    AspectPriority = aspectAttribute.AspectPriority,
                    LifetimeStrategy = aspectAttribute.LifetimeStrategy
                };

                var raiseEventAspect = new RaiseEventFragmentInterceptionAspect {
                    AspectType = aspectAttribute.AspectType,
                    AspectPriority = aspectAttribute.AspectPriority,
                    LifetimeStrategy = aspectAttribute.LifetimeStrategy
                };

                var removeEventAspect = new RemoveEventFragmentInterceptionAspect {
                    AspectType = aspectAttribute.AspectType,
                    AspectPriority = aspectAttribute.AspectPriority,
                    LifetimeStrategy = aspectAttribute.LifetimeStrategy
                };

                AddOrUpdate(target, @event, addMethod, new[] { new AddEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, addEventAspect, aspectDeclaringType, target) });
                AddOrUpdate(raiseMethodHash, target, @event, raiseMethod, new[] { new RaiseEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, raiseEventAspect, aspectDeclaringType, target) });
                AddOrUpdate(target, @event, removeMethod, new[] { new RemoveEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, removeEventAspect, aspectDeclaringType, target) });
            });
        }

        private void CollectPartialPropertyAspectDefinitionsByPropertyInterceptionAttribute(IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                MethodInfo method = null;
                var propertyInterceptionAspects = new List<IAspectDefinition>();

                if (propertyMap.Target.IsNotNull()) {
                    propertyMap.Members.ForEach(property => {
                        IEnumerable<IAspectDefinition> aspectDefinitions = null;
                        var aspectsAttrs = property.GetCustomAttributes<PropertyInterceptionAspectAttribute>().ToArray();

                        if (aspectsAttrs.IsNotNullOrEmpty()) {
                            if (property.CanWrite) {
                                method = propertyMap.Target.GetSetMethod();
                                aspectDefinitions = aspectsAttrs.Select(aspectAttr => {
                                    var aspect = new SetPropertyInterceptionAspect {
                                        AspectType = aspectAttr.AspectType,
                                        AspectPriority = aspectAttr.AspectPriority,
                                        LifetimeStrategy = aspectAttr.LifetimeStrategy
                                    };

                                    return new SetPropertyInterceptionAspectDefinition(aspect, propertyMap.ContractType, propertyMap.ContractMember);
                                });
                            }
                            else {
                                method = propertyMap.Target.GetGetMethod();
                                aspectDefinitions = aspectsAttrs.Select(aspectAttr => {
                                    var aspect = new GetPropertyInterceptionAspect {
                                        AspectType = aspectAttr.AspectType,
                                        AspectPriority = aspectAttr.AspectPriority,
                                        LifetimeStrategy = aspectAttr.LifetimeStrategy
                                    };

                                    return new GetPropertyInterceptionAspectDefinition(aspect, propertyMap.ContractType, propertyMap.ContractMember);
                                });
                            }

                            propertyInterceptionAspects.AddRange(aspectDefinitions);
                        }
                    });

                    AddOrUpdate(propertyMap.Target, propertyMap.ContractMember, method, propertyInterceptionAspects);
                }
            });
        }

        private void CollectFullPropertyAspectDefinitions(IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                propertyMap.Members.ForEach(property => {
                    var propertyGetMethod = property.GetGetMethod();
                    var propertySetMethod = property.GetSetMethod();

                    property.GetCustomAttributes<PropertyInterceptionAspectAttribute>()
                            .ForEach(aspectAttribute => {
                                CollectPropertyInterceptionAspectDefinition(propertyMap, propertyGetMethod, propertySetMethod, propertyMap.ContractType, aspectAttribute);
                            });
                });
            });
        }

        private void CollectPropertyInterceptionAspectDefinition(IAspectPropertyMap propertyMap, MethodInfo propertyGetMethod, MethodInfo propertySetMethod, Type aspectDeclaringType, PropertyInterceptionAspectAttribute aspectAttribute) {
            var contract = propertyMap.ContractMember;
            var aspectDefinition = new PropertyInterceptionAspectsDefinition(aspectAttribute, aspectAttribute.AspectType, contract);
            var bindingTypeReflectorBuilder = new FullPropertyBindingTypeReflectorBuilder(aspectDefinition);

            var getPropertyAspect = new GetPropertyFragmentInterceptionAspect {
                AspectType = aspectAttribute.AspectType,
                AspectPriority = aspectAttribute.AspectPriority,
                LifetimeStrategy = aspectAttribute.LifetimeStrategy
            };

            var setPropertyAspect = new SetPropertyFragmentInterceptionAspect {
                AspectType = aspectAttribute.AspectType,
                AspectPriority = aspectAttribute.AspectPriority,
                LifetimeStrategy = aspectAttribute.LifetimeStrategy
            };

            AddOrUpdate(propertyMap.Target, contract, propertyGetMethod, new[] { new GetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, getPropertyAspect, aspectDeclaringType, contract) });
            AddOrUpdate(propertyMap.Target, contract, propertySetMethod, new[] { new SetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, setPropertyAspect, aspectDeclaringType, contract) });
        }

        public IEnumerator<AspectMap> GetEnumerator() {
            return registry.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}