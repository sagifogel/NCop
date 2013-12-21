using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpression : IAspectExpression
    {
        private readonly IAspectExpression expression = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IAspectDefinitionCollection aspectsDefinitions = null;
        private readonly ILocalBuilderRepository localBuilderRepository = null;

        internal AspectExpression(IAspectExpression expression, IAspectDefinitionCollection aspectsDefinitions, Type firstAspectArgsType, IWeavingSettings weavingSettings) {
            IEnumerable<Type> parameters = null;
            IAspectArgumentsWeaver argumentsWeaver = null;

            this.expression = expression;
            this.aspectsDefinitions = aspectsDefinitions;
            localBuilderRepository = new LocalBuilderRepository();
            parameters = weavingSettings.MethodInfoImpl.GetParameters().Select(@param => @param.ParameterType);
            argumentsWeaver = new MethodImplArgumentsWeaver(firstAspectArgsType, parameters.ToArray(), weavingSettings, localBuilderRepository);
            aspectWeavingSettings = new AspectWeavingSettings(weavingSettings, argumentsWeaver);
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings settings) {
            return new AspectsWeaver(expression, aspectsDefinitions, aspectWeavingSettings);
        }
    }
}
