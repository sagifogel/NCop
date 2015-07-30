using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using NCop.Core.Lib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class AspectAttributesMemberMatcher : Tuples<MemberInfo, IAspectDefinitionCollection>
    {
        private static readonly bool partial = true;
        private readonly ConcurrentDictionary<MemberInfo, IAspectDefinitionCollection> registry = null;

        public AspectAttributesMemberMatcher(IAspectMemebrsCollection aspectMembersCollection) {
            registry = new ConcurrentDictionary<MemberInfo, IAspectDefinitionCollection>();
            CollectEventsAspectDefinitions(aspectMembersCollection);
            CollectMethodsAspectDefinitions(aspectMembersCollection);
            CollectPropertiesAspectDefinitions(aspectMembersCollection);
            values = registry.Select(keyValue => Tuple.Create(keyValue.Key, keyValue.Value));
        }

        private void CollectMethodsAspectDefinitions(IAspectMethodMapCollection aspectMembersCollection) {
            aspectMembersCollection.Methods.ForEach(aspectMembers => {
                var aspects = aspectMembers.Members.SelectMany(member => {
                    return CollectMethodsAspectDefinitions(member, aspectMembers.ContractType, aspectMembers.Target);
                });

                AddOrUpdate(aspectMembers.Target, aspects.ToList());
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

        private void AddOrUpdate(MemberInfo member, ICollection<IAspectDefinition> aspects) {
            if (aspects.Count > 0) {
                var aspectCollection = registry.GetOrAdd(member, new AspectDefinitionCollection());

                aspectCollection.AddRange(aspects);
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
            var eventInterceptionAspect = @event.GetCustomAttributes<EventInterceptionAspectAttribute>();

            eventInterceptionAspect.ForEach(aspectAttribute => {
                var addMethod = target.GetAddMethod();
                var removeMethod = target.GetRemoveMethod();
                var raiseMethod = target.GetInvokeMethod();
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

                AddOrUpdate(addMethod, new[] { new AddEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, addEventAspect, aspectDeclaringType, target) });
                AddOrUpdate(raiseMethod, new[] { new RaiseEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, raiseEventAspect, aspectDeclaringType, target) });
                AddOrUpdate(removeMethod, new[] { new RemoveEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, removeEventAspect, aspectDeclaringType, target) });
            });
        }

        private void CollectPartialPropertyAspectDefinitionsByPropertyInterceptionAttribute(IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                MethodInfo target = null;
                var propertyInterceptionAspects = new List<IAspectDefinition>();

                if (propertyMap.Target.IsNotNull()) {
                    propertyMap.Members.ForEach(property => {
                        IEnumerable<IAspectDefinition> aspectDefinitions = null;
                        var aspectsAttrs = property.GetCustomAttributes<PropertyInterceptionAspectAttribute>().ToArray();

                        if (aspectsAttrs.IsNotNullOrEmpty()) {
                            if (property.CanWrite) {
                                target = propertyMap.Target.GetSetMethod();
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
                                target = propertyMap.Target.GetGetMethod();
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

                    AddOrUpdate(target, propertyInterceptionAspects);
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
            var target = propertyMap.ContractMember;
            var setMethodTarget = propertyMap.ContractMember.GetSetMethod();
            var getMethodTarget = propertyMap.ContractMember.GetGetMethod();
            var aspectDefinition = new PropertyInterceptionAspectsDefinition(aspectAttribute, aspectAttribute.AspectType, target);
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

            AddOrUpdate(propertyGetMethod, new[] { new GetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, getPropertyAspect, aspectDeclaringType, target) });
            AddOrUpdate(propertySetMethod, new[] { new SetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, setPropertyAspect, aspectDeclaringType, target) });
        }
    }
}