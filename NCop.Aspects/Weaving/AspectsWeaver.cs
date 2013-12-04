using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class AspectsWeaver : IAspcetWeaver
    {
        private readonly IAspectExpression expression = null;
        private readonly IAspectWeaverSettings settings = null;
        private readonly AspectsAttributeWeaver aspectAttributeWeaver = null;

        public AspectsWeaver(IAspectExpression expression, IAspectDefinitionCollection aspectDefinitions, IContextWeaver contextWeaver) {
            this.expression = expression;
            aspectAttributeWeaver = new AspectsAttributeWeaver(aspectDefinitions);

            this.settings = new AspectWeaverSettings {
                ContextWeaver = contextWeaver,
                AspectRepository = aspectAttributeWeaver
            };
        }

        public ILGenerator Weave(ILGenerator iLGenerator) {
            IAspcetWeaver weaver = null;

            aspectAttributeWeaver.Weave();
            weaver = expression.Reduce(settings);

            return weaver.Weave(iLGenerator);
        }

        public string Name { get; private set; }
    }
}
