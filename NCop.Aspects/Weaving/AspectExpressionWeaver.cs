using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectExpressionWeaver : IAspcetWeaver
    {
        private readonly IAspectExpression expression = null;
        private readonly IAspectWeaverSettings settings = null;
        private readonly AspectsAttributeWeaver aspectRepository = null;

        public AspectExpressionWeaver(IAspectExpression expression, AspectsAttributeWeaver aspectRepositoryWeaver, IAspectWeaverSettings settings) {
            this.settings = settings;
            this.expression = expression;
            this.aspectRepository = aspectRepositoryWeaver;
        }

        public ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            IAspcetWeaver weaver = null;

            aspectRepository.Weave();
            weaver = expression.Reduce(settings);

            return weaver.Weave(iLGenerator, typeDefinition);
        }
    }
}
