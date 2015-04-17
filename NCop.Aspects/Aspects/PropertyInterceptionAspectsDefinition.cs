using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal sealed class PropertyInterceptionAspectsDefinition : IPropertyAspectDefinition
    {
        public PropertyInterceptionAspectsDefinition(IAspect aspect, Type aspectDeclaringType, PropertyInfo property) {
            Aspect = aspect;
            Member = property;
            AspectDeclaringType = aspectDeclaringType;
        }

        public AspectType AspectType {
            get {
                return AspectType.PropertyInterceptionAspect;
            }
        }
        public IAspect Aspect { get; private set; }

        public MethodInfo Method { get; private set; }

        public PropertyInfo Member { get; private set; }

        public Type AspectDeclaringType { get; private set; }

        public IAdviceDefinitionCollection Advices { get; private set; }

        public IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            throw new NotSupportedException();
        }

        public IAspectDefinition BuildAdvices() {
            throw new NotSupportedException();
        }
    }
}
