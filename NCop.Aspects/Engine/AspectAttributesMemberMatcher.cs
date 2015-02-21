using System.Collections.Concurrent;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using NCop.Core.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Engine
{
    public class AspectAttributesMemberMatcher : Tuples<MemberInfo, IAspectDefinitionCollection>
    {
        private readonly ConcurrentDictionary<MethodInfo, IAspectDefinitionCollection> registry = null;

        public AspectAttributesMemberMatcher(Type aspectDeclaringType, IAspectMemebrsCollection aspectMembersCollection) {
            registry = new ConcurrentDictionary<MethodInfo, IAspectDefinitionCollection>();
            CollectMethodsAspectDefinitions(aspectDeclaringType, aspectMembersCollection);
            CollectPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection);
            Values = registry.Select(keyValue => Tuple.Create(keyValue.Key as MemberInfo, keyValue.Value));
        }

        private void CollectMethodsAspectDefinitions(Type aspectDeclaringType, IAspectMethodMapCollection aspectMembersCollection) {
            aspectMembersCollection.Methods.ForEach(aspectMembers => {
                var aspects = aspectMembers.Members.SelectMany(member => {
                    return CollectMethodsAspectDefinitions(member, aspectDeclaringType, aspectMembers.Target);
                });

                AddOrUpdate(aspectMembers.Target, aspects);
            });
        }

        private void AddOrUpdate(MethodInfo method, IEnumerable<IAspectDefinition> aspects) {
            var aspectCollection = registry.GetOrAdd(method, new AspectDefinitionCollection());

            aspectCollection.AddRange(aspects);
        }

        private void CollectPropertiesAspectDefinitions(Type aspectDeclaringType, IAspectPropertyMapCollection aspectMembersCollection) {
            CollectPartialGetPropertyAspectDefinitions(aspectDeclaringType, aspectMembersCollection.Properties);
            CollectPartialSetPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection.Properties);
            CollectFullPropertyAspectDefinitions(aspectDeclaringType, aspectMembersCollection.Properties);
        }

        private IEnumerable<IAspectDefinition> CollectMethodsAspectDefinitions(MethodInfo member, Type aspectDeclaringType, MethodInfo target) {
            var onMethodBoundaryAspects = member.GetCustomAttributes<OnMethodBoundaryAspectAttribute>();
            var methodInterceptionAspects = member.GetCustomAttributes<MethodInterceptionAspectAttribute>();

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

        private void CollectPartialSetPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            CollectPartialPropertiesAspectDefinitions<SetPropertyInterceptionAspectAttribute>(properties, prop => prop.GetSetMethod(), (aspectsAttrs, method, property) => {
                return aspectsAttrs.Select(aspectAttr => new SetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, method, property));
            });
        }

        private void CollectPartialPropertiesAspectDefinitions<TArribute>(IEnumerable<IAspectPropertyMap> properties, Func<PropertyInfo, MethodInfo> methodResolver, Func<IEnumerable<TArribute>, MethodInfo, PropertyInfo, IEnumerable<IAspectDefinition>> definitionFactory) where TArribute : Attribute {
            properties.Where(propertyMap => propertyMap.IsPartial)
                      .ForEach(propertyMap => {
                          var target = methodResolver(propertyMap.Target);
                          var getPropertyInterceptionAspects = new List<IAspectDefinition>();

                          propertyMap.Members.ForEach(property => {
                              var getMethod = methodResolver(property);
                              var getPropertyInterceptionAspectsAttrs = getMethod.GetCustomAttributes<TArribute>();

                              getPropertyInterceptionAspects.AddRange(definitionFactory(getPropertyInterceptionAspectsAttrs, getMethod, property));
                          });

                          AddOrUpdate(target, getPropertyInterceptionAspects);
                      });
        }

        private void CollectFullPropertyAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            properties.ForEach(propertyMap => {
                propertyMap.Members.ForEach(property => {
                    var propertyGetMethod = property.GetGetMethod();
                    var propertySetMethod = property.GetSetMethod();
                    var propertyInterceptionAspectsAttrs = property.GetCustomAttributes<PropertyInterceptionAspectAttribute>();
                    var getPropertyInterceptionAspectsAttrs = propertyGetMethod.GetCustomAttributes<GetPropertyInterceptionAspectAttribute>();
                    var setPropertyInterceptionAspectsAttrs = propertySetMethod.GetCustomAttributes<SetPropertyInterceptionAspectAttribute>();

                    propertyInterceptionAspectsAttrs.ForEach(aspectAttribute => {
                        CollectPropertyInterceptionAspectDefinition(propertyMap, propertyGetMethod, propertySetMethod, aspectDeclaringType, aspectAttribute);
                    });

                    getPropertyInterceptionAspectsAttrs.ForEach(aspectAttribute => {
                        CollectPropertyPartialAspectDefinition(propertyMap, propertyGetMethod, propertySetMethod, aspectDeclaringType, aspectAttribute, aspectDefinition => new GetPropertyBindingTypeReflectorBuilder(aspectDefinition));
                    });

                    setPropertyInterceptionAspectsAttrs.ForEach(aspectAttribute => {
                        CollectPropertyPartialAspectDefinition(propertyMap, propertyGetMethod, propertySetMethod, aspectDeclaringType, aspectAttribute, aspectDefinition => new SetPropertyBindingTypeReflectorBuilder(aspectDefinition));
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
