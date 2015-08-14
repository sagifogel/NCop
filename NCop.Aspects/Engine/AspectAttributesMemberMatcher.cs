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
                    return CollectMethodsAspectDefinitions(aspectMembers.ContractType, aspectMembers.Target, member);
                });

                AddOrUpdate(aspectMembers.Target, aspectMembers.ContractMember, aspectMembers.Target, aspects.ToList());
            });
        }

        private void CollectEventsAspectDefinitions(IAspectEventMapCollection aspectMembersCollection) {
            aspectMembersCollection.Events.ForEach(aspectMembers => {
                aspectMembers.Members.ForEach(member => {
                    CollectEventsAspectDefinitions(aspectMembers.ContractType, aspectMembers.ContractMember, member);
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

        private IEnumerable<IAspectDefinition> CollectMethodsAspectDefinitions(Type aspectDeclaringType, MethodInfo contract, MethodInfo target) {
            var onMethodBoundaryAspects = target.GetCustomAttributes<OnMethodBoundaryAspectAttribute>();
            var methodInterceptionAspects = target.GetCustomAttributes<MethodInterceptionAspectAttribute>();

            var onMethodBoundaryAspectDefinitions = onMethodBoundaryAspects.Select(aspect => {
                return new OnMethodBoundaryAspectDefinition(aspect, aspectDeclaringType, contract, target);
            });

            var methodInterceptionAspectDefinitions = methodInterceptionAspects.Select(aspect => {
                return new MethodInterceptionAspectDefinition(aspect, aspectDeclaringType, contract, target);
            });

            return methodInterceptionAspectDefinitions.Cast<IAspectDefinition>()
                                                      .Concat(onMethodBoundaryAspectDefinitions);
        }

        private void CollectEventsAspectDefinitions(Type aspectDeclaringType, EventInfo contract, EventInfo target) {
            var addMethod = contract.GetAddMethod();
            var raiseMethod = contract.GetInvokeMethod();
            var removeMethod = contract.GetRemoveMethod();
            var raiseMethodHash = Guid.NewGuid().GetHashCode();
            var eventInterceptionAspect = target.GetCustomAttributes<EventInterceptionAspectAttribute>();

            eventInterceptionAspect.ForEach(aspectAttribute => {
                var aspectDefinition = new EventInterceptionAspectDefinition(aspectAttribute, aspectAttribute.AspectType, contract, target);
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

                AddOrUpdate(contract, target, addMethod, new[] { new AddEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, addEventAspect, aspectDeclaringType, contract, target) });
                AddOrUpdate(raiseMethodHash, contract, target, raiseMethod, new[] { new RaiseEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, raiseEventAspect, aspectDeclaringType, contract, target) });
                AddOrUpdate(contract, target, removeMethod, new[] { new RemoveEventFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, removeEventAspect, aspectDeclaringType, contract, target) });
            });
        }

        private void CollectPartialPropertyAspectDefinitionsByPropertyInterceptionAttribute(IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                MethodInfo method = null;
                var propertyInterceptionAspects = new List<IAspectDefinition>();

                if (propertyMap.Target.IsNotNull()) {
                    propertyMap.Members.ForEach(targetMember => {
                        IEnumerable<IAspectDefinition> aspectDefinitions = null;
                        var aspectsAttrs = targetMember.GetCustomAttributes<PropertyInterceptionAspectAttribute>().ToArray();

                        if (aspectsAttrs.IsNotNullOrEmpty()) {
                            if (targetMember.CanWrite) {
                                method = propertyMap.Target.GetSetMethod();
                                aspectDefinitions = aspectsAttrs.Select(aspectAttr => {
                                    var aspect = new SetPropertyInterceptionAspect {
                                        AspectType = aspectAttr.AspectType,
                                        AspectPriority = aspectAttr.AspectPriority,
                                        LifetimeStrategy = aspectAttr.LifetimeStrategy
                                    };

                                    return new SetPropertyInterceptionAspectDefinition(aspect, propertyMap.ContractType, propertyMap.ContractMember, targetMember);
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

                                    return new GetPropertyInterceptionAspectDefinition(aspect, propertyMap.ContractType, propertyMap.ContractMember, targetMember);
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
                propertyMap.Members.ForEach(targetMember => {
                    targetMember.GetCustomAttributes<PropertyInterceptionAspectAttribute>()
                                .ForEach(aspectAttribute => {
                                    CollectPropertyInterceptionAspectDefinition(propertyMap, targetMember, propertyMap.ContractType, aspectAttribute);
                                });
                });
            });
        }

        private void CollectPropertyInterceptionAspectDefinition(IAspectPropertyMap propertyMap, PropertyInfo target, Type aspectDeclaringType, PropertyInterceptionAspectAttribute aspectAttribute) {
            var contract = propertyMap.ContractMember;
            var propertyGetMethod = target.GetGetMethod();
            var propertySetMethod = target.GetSetMethod();
            var contractGetMethodHasCode = contract.GetGetMethod().GetHashCode();
            var contractSetMethodHasCode = contract.GetSetMethod().GetHashCode();
            var aspectDefinition = new PropertyInterceptionAspectsDefinition(aspectAttribute, aspectAttribute.AspectType, contract, target);
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

            AddOrUpdate(contractGetMethodHasCode, propertyMap.Target, contract, propertyGetMethod, new[] { new GetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, getPropertyAspect, aspectDeclaringType, contract, target) });
            AddOrUpdate(contractSetMethodHasCode, propertyMap.Target, contract, propertySetMethod, new[] { new SetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, setPropertyAspect, aspectDeclaringType, contract, target) });
        }

        public IEnumerator<AspectMap> GetEnumerator() {
            return registry.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}