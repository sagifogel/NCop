using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAspectArgumentsWeaver : IAspectArgumentWeaver
    {
        protected LocalBuilder localBuilder = null;
        protected readonly Type[] parameters = null;

        public AbstractAspectArgumentsWeaver(Type argumentType, Type[] parameters) {
            ArgumentType = argumentType;
            this.parameters = new Type[parameters.Length];
            parameters.CopyTo(this.parameters, 0);
            IsFunction = argumentType.IsFunctionAspectArgs();
        }

        public bool IsFunction { get; private set; }

        public Type ArgumentType { get; private set; }

        public virtual LocalBuilder Weave(ILGenerator ilGenerator) {
            return localBuilder ?? (localBuilder = BuildArguments(ilGenerator, parameters));
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters);
    }
}
