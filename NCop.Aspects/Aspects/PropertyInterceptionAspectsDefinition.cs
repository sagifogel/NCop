using System;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    internal sealed class PropertyInterceptionAspectsDefinition : IPropertyAspectDefinition
    {
        public PropertyInterceptionAspectsDefinition(Type aspectDeclaringType, PropertyInfo property) {
            Property = property;
            AspectDeclaringType = aspectDeclaringType;
        }

        public AspectType AspectType {
            get {
                return AspectType.PropertyInterceptionAspect;
            }
        }
        public IAspect Aspect { get; private set; }

        public PropertyInfo Property { get; private set; }

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
