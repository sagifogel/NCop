using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using NCop.Core.Lib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class AspectAttributesMemberMatcher : Tuples<MethodInfo, IAspectDefinitionCollection>
    {
        private static readonly bool partial = true;
        private readonly ConcurrentDictionary<MethodInfo, IAspectDefinitionCollection> registry = null;

        public AspectAttributesMemberMatcher(Type aspectDeclaringType, IAspectMemebrsCollection aspectMembersCollection) {
            registry = new ConcurrentDictionary<MethodInfo, IAspectDefinitionCollection>();
            CollectMethodsAspectDefinitions(aspectDeclaringType, aspectMembersCollection);
            CollectPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection);
            Values = registry.Select(keyValue => Tuple.Create(keyValue.Key, keyValue.Value));
        }

        private void CollectMethodsAspectDefinitions(Type aspectDeclaringType, IAspectMethodMapCollection aspectMembersCollection) {
            aspectMembersCollection.Methods.ForEach(aspectMembers => {
                var aspects = aspectMembers.Members.SelectMany(member => {
                    return CollectMethodsAspectDefinitions(member, aspectDeclaringType, aspectMembers.Target);
                });

                AddOrUpdate(aspectMembers.Target, aspects.ToList());
            });
        }

        private void AddOrUpdate(MethodInfo method, ICollection<IAspectDefinition> aspects) {
            if (aspects.Count > 0) {
                var aspectCollection = registry.GetOrAdd(method, new AspectDefinitionCollection());

                aspectCollection.AddRange(aspects);
            }
        }

        private void CollectPropertiesAspectDefinitions(Type aspectDeclaringType, IAspectPropertyMapCollection aspectMembersCollection) {
            List<IAspectPropertyMap> properties = null;
            var groupedProperties = aspectMembersCollection.Properties.ToGroupedDictionary(map => map.IsPartial, group => group.ToList());

            if (groupedProperties.TryGetValue(partial, out properties)) {
                CollectPartialGetPropertyAspectDefinitions(aspectDeclaringType, properties);
                CollectPartialSetPropertyAspectDefinitions(aspectDeclaringType, properties);
                CollectPartialPropertyAspectDefinitionsByPropertyInterceptionAttribute(aspectDeclaringType, properties);
            }

            if (groupedProperties.TryGetValue(!partial, out properties)) {
                CollectFullPropertyAspectDefinitions(aspectDeclaringType, properties);
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

        private void CollectPartialGetPropertyAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            CollectPartialPropertiesAspectDefinitions<GetPropertyInterceptionAspectAttribute>(properties, prop => prop.GetGetMethod(), (aspectsAttrs, method, property) => {
                return aspectsAttrs.Select(aspectAttr => new GetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, method, property));
            });
        }

        private void CollectPartialSetPropertyAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            CollectPartialPropertiesAspectDefinitions<SetPropertyInterceptionAspectAttribute>(properties, prop => prop.GetSetMethod(), (aspectsAttrs, method, property) => {
                return aspectsAttrs.Select(aspectAttr => new SetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, method, property));
            });
        }

        private void CollectPartialPropertyAspectDefinitionsByPropertyInterceptionAttribute(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                MethodInfo target = null;
                var propertyInterceptionAspects = new List<IAspectDefinition>();

                if (propertyMap.Target.IsNotNull()) {
                    propertyMap.Members.ForEach(property => {
                        MethodInfo contractMethod = null;
                        IEnumerable<IAspectDefinition> aspectDefinitions = null;
                        var aspectsAttrs = property.GetCustomAttributes<PropertyInterceptionAspectAttribute>().ToArray();

                        if (aspectsAttrs.IsNotNullOrEmpty()) {
                            if (property.CanWrite) {
                                target = propertyMap.Target.GetSetMethod();
                                contractMethod = propertyMap.ContractMember.GetSetMethod();
                                aspectDefinitions = aspectsAttrs.Select(aspectAttr => {
                                    var aspect = new SetPropertyInterceptionAspectAttribute(aspectAttr.AspectType) {
                                        AspectPriority = aspectAttr.AspectPriority,
                                        LifetimeStrategy = aspectAttr.LifetimeStrategy
                                    };

                                    return new SetPropertyInterceptionAspectDefinition(aspect, aspectDeclaringType, contractMethod, property);
                                });
                            }
                            else {
                                target = propertyMap.Target.GetGetMethod();
                                contractMethod = propertyMap.ContractMember.GetGetMethod();
                                aspectDefinitions = aspectsAttrs.Select(aspectAttr => {
                                    var aspect = new GetPropertyInterceptionAspectAttribute(aspectAttr.AspectType) {
                                        AspectPriority = aspectAttr.AspectPriority,
                                        LifetimeStrategy = aspectAttr.LifetimeStrategy
                                    };

                                    return new GetPropertyInterceptionAspectDefinition(aspect, aspectDeclaringType, contractMethod, property);
                                });
                            }

                            propertyInterceptionAspects.AddRange(aspectDefinitions);
                        }
                    });

                    AddOrUpdate(target, propertyInterceptionAspects);
                }
            });
        }

        private void CollectPartialPropertiesAspectDefinitions<TAttribute>(IEnumerable<IAspectPropertyMap> properties, Func<PropertyInfo, MethodInfo> methodResolver, Func<IEnumerable<TAttribute>, MethodInfo, PropertyInfo, IEnumerable<IAspectDefinition>> definitionFactory) where TAttribute : Attribute {
            properties.ForEach(propertyMap => {
                var target = methodResolver(propertyMap.ContractMember);
                var propertyInterceptionAspects = new List<IAspectDefinition>();

                if (target.IsNotNull()) {
                    propertyMap.Members.ForEach(property => {
                        var method = methodResolver(property);

                        if (method.IsNotNull()) {
                            var propertyInterceptionAspectsAttrs = method.GetCustomAttributes<TAttribute>();

                            propertyInterceptionAspects.AddRange(definitionFactory(propertyInterceptionAspectsAttrs, method, property));
                        }
                    });

                    AddOrUpdate(target, propertyInterceptionAspects);
                }
            });
        }

        private void CollectFullPropertyAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                propertyMap.Members.ForEach(property => {
                    var propertyGetMethod = property.GetGetMethod();
                    var propertySetMethod = property.GetSetMethod();

                    property.GetCustomAttributes<PropertyInterceptionAspectAttribute>()
                            .ForEach(aspectAttribute => {
                                CollectPropertyInterceptionAspectDefinition(propertyMap, propertyGetMethod, propertySetMethod, aspectDeclaringType, aspectAttribute);
                            });

                    if (propertyGetMethod.IsNotNull()) {
                        propertyGetMethod.GetCustomAttributes<GetPropertyInterceptionAspectAttribute>()
                                         .ForEach(aspectAttribute => {
                                             CollectPropertyPartialAspectDefinition(propertyMap, propertyGetMethod, propertySetMethod, aspectDeclaringType, aspectAttribute, aspectDefinition => new GetPropertyBindingTypeReflectorBuilder(aspectDefinition));
                                         });
                    }

                    if (propertySetMethod.IsNotNull()) {
                        propertySetMethod.GetCustomAttributes<SetPropertyInterceptionAspectAttribute>()
                                         .ForEach(aspectAttribute => {
                                             CollectPropertyPartialAspectDefinition(propertyMap, propertyGetMethod, propertySetMethod, aspectDeclaringType, aspectAttribute, aspectDefinition => new SetPropertyBindingTypeReflectorBuilder(aspectDefinition));
                                         });
                    }
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

            AddOrUpdate(propertyGetMethod, new[] { new GetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, getPropertyAspect, aspectDeclaringType, getMethodTarget, target) });
            AddOrUpdate(propertySetMethod, new[] { new SetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, setPropertyAspect, aspectDeclaringType, setMethodTarget, target) });
        }

        private void CollectPropertyPartialAspectDefinition<TAspectAttribute>(IAspectPropertyMap propertyMap, MethodInfo propertyGetMethod, MethodInfo propertySetMethod, Type aspectDeclaringType, TAspectAttribute aspectAttribute, Func<IPropertyAspectDefinition, IPropertyExpressionBuilder> expressionBuilderFactory) where TAspectAttribute : AspectAttribute {
            var target = propertyMap.ContractMember;
            var setMethodTarget = propertyMap.ContractMember.GetSetMethod();
            var getMethodTarget = propertyMap.ContractMember.GetGetMethod();
            var aspectDefinition = new PropertyInterceptionAspectsDefinition(aspectAttribute, aspectAttribute.AspectType, target);
            var bindingTypeReflectorBuilder = expressionBuilderFactory(aspectDefinition);

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

            AddOrUpdate(propertyGetMethod, new[] { new GetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, getPropertyAspect, aspectDeclaringType, getMethodTarget, target) });
            AddOrUpdate(propertySetMethod, new[] { new SetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, setPropertyAspect, aspectDeclaringType, setMethodTarget, target) });
        }
    }
}