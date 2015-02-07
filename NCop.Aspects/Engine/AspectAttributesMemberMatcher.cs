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
            CollectGetPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection.Properties);
            CollectSetPropertiesAspectDefinitions(aspectDeclaringType, aspectMembersCollection.Properties);
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

        private void CollectGetPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            CollectPropertiesAspectDefinitions<GetPropertyInterceptionAspectAttribute>(properties, prop => prop.GetGetMethod(), (aspectsAttrs, method, property) => {
                return aspectsAttrs.Select(aspectAttr => new GetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, method, property));
            });

            CollectFullPropertiesAspectDefinitions(aspectDeclaringType, properties, aspectDefinition => new FullPropertyBindingTypeReflectorBuilder(aspectDefinition));
        }

        private void CollectSetPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties) {
            CollectPropertiesAspectDefinitions<SetPropertyInterceptionAspectAttribute>(properties, prop => prop.GetSetMethod(), (aspectsAttrs, method, property) => {
                return aspectsAttrs.Select(aspectAttr => new SetPropertyInterceptionAspectDefinition(aspectAttr, aspectDeclaringType, method, property));
            });

            CollectFullPropertiesAspectDefinitions(aspectDeclaringType, properties, aspectDefinition => new FullPropertyBindingTypeReflectorBuilder(aspectDefinition));
        }

        private void CollectPropertiesAspectDefinitions<TArribute>(IEnumerable<IAspectPropertyMap> properties, Func<PropertyInfo, MethodInfo> methodResolver, Func<IEnumerable<TArribute>, MethodInfo, PropertyInfo, IEnumerable<IAspectDefinition>> definitionFactory) where TArribute : Attribute {
            properties.ForEach(propertyMap => {
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

        private void CollectFullPropertiesAspectDefinitions(Type aspectDeclaringType, IEnumerable<IAspectPropertyMap> properties, Func<IPropertyAspectDefinition, IPropertyExpressionBuilder> expressionPropertyBuilder) {
            properties.ForEach(propertyMap => {
                var target = propertyMap.ContractMember;
                var setMethodTarget = propertyMap.ContractMember.GetSetMethod();
                var getMethodTarget = propertyMap.ContractMember.GetGetMethod();

                propertyMap.Members.ForEach(property => {
                    var getMethod = property.GetGetMethod();
                    var setMethod = property.GetSetMethod();
                    var propertyInterceptionAspectsAttrs = property.GetCustomAttributes<PropertyInterceptionAspectAttribute>();

                    propertyInterceptionAspectsAttrs.ForEach(aspectAttribute => {
                        var aspectDefinition = new PropertyInterceptionAspectsDefinition(aspectAttribute.AspectType, target);
                        var bindingTypeReflectorBuilder = expressionPropertyBuilder(aspectDefinition);

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

                        AddOrUpdate(getMethod, new[] { new GetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, getPropertyAspect, aspectDeclaringType, getMethodTarget, target) });
                        AddOrUpdate(setMethod, new[] { new SetPropertyFragmentInterceptionAspectDefinition(bindingTypeReflectorBuilder, setPropertyAspect, aspectDeclaringType, setMethodTarget, target) });
                    });
                });
            });
        }
    }
}
