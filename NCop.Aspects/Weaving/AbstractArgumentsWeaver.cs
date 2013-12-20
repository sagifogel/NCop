using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractArgumentsWeaver : IArgumentsWeaver
    {
        protected readonly Type[] parameters = null;

        public AbstractArgumentsWeaver(Type argumentType, Type[] parameters, IWeavingSettings weavingSettings, ILocalBuilderRepository localBuilderRepository) {
            var @params = new Type[parameters.Length];

            ArgumentType = argumentType;
            WeavingSettings = weavingSettings;
            parameters.CopyTo(@params, 0);
            Parameters = @params;
            IsFunction = argumentType.IsFunctionAspectArgs();
            LocalBuilderRepository = localBuilderRepository;
        }

        public bool IsFunction { get; protected set; }

        public Type ArgumentType { get; protected set; }

        public Type[] Parameters { get; protected set; }

        public IWeavingSettings WeavingSettings { get; protected set; }

        public ILocalBuilderRepository LocalBuilderRepository { get; protected set; }

        public abstract void Weave(ILGenerator ilGenerator);
    }
}
