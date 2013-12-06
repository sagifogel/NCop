using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpression : IAspectExpression
    {
        private readonly IAspectExpression expression = null;
        private readonly IAspectArgumentWeaver argumentsWeaver = null;
        private readonly IAspectDefinitionCollection aspectsDefinitions = null;

        internal AspectExpression(IAspectExpression expression, IAspectDefinitionCollection aspectsDefinitions, Type firstAspectArgsType, MethodInfo methodInfoImpl) {
            IEnumerable<Type> parameters = null;

            this.expression = expression;
            this.aspectsDefinitions = aspectsDefinitions;
            parameters = methodInfoImpl.GetParameters().Select(@param => @param.ParameterType);
            argumentsWeaver = new MethodImplArgumentsWeaver(firstAspectArgsType, parameters.ToArray());
        }

        public IAspcetWeaver Reduce(IAspectWeavingSettings settings) {
            return new AspectsWeaver(expression, aspectsDefinitions, argumentsWeaver);
        }
    }
}
