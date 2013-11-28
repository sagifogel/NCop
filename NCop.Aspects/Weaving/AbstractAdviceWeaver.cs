using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAdviceWeaver : IMethodScopeWeaver
    {   
        protected readonly IMethodLocalWeaver aspectArgsLocalWeaver = null;

        public AbstractAdviceWeaver(IMethodLocalWeaver aspectArgsLocalWeaver) {
            this.aspectArgsLocalWeaver = aspectArgsLocalWeaver;
        }

        public abstract ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition);
    }
}
