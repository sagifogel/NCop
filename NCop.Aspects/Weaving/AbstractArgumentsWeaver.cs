using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractArgumentsWeaver : IArgumentsWeaver, IArgumentsWeavingSettings
    {
        protected readonly MethodInfo method = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;

        internal AbstractArgumentsWeaver(MethodInfo method, IArgumentsWeavingSettings argumentsWeavingSettings, IAspectWeavingSettings aspectWeavingSettings) {
            this.method = method;
            ReturnType = argumentsWeavingSettings.ReturnType;
            AspectType = argumentsWeavingSettings.AspectType;
            Parameters = new Type[argumentsWeavingSettings.Parameters.Length];
            LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            ArgumentType = argumentsWeavingSettings.ArgumentType;
            argumentsWeavingSettings.Parameters.CopyTo(Parameters, 0);
            IsFunction = argumentsWeavingSettings.IsFunction;
            this.aspectWeavingSettings = aspectWeavingSettings;
            WeavingSettings = aspectWeavingSettings.WeavingSettings;
            BindingsDependency = argumentsWeavingSettings.BindingsDependency;
        }

        public bool IsProperty { get; set; }

        public Type ReturnType { get; set; }

        public Type AspectType { get; protected set; }

        public bool IsFunction { get; protected set; }

        public Type ArgumentType { get; protected set; }

        public Type[] Parameters { get; protected set; }

        public FieldInfo BindingsDependency { get; protected set; }

        public IWeavingSettings WeavingSettings { get; protected set; }

        public IByRefArgumentsStoreWeaver ByRefArgumentsStoreWeaver { get; set; }

        public ILocalBuilderRepository LocalBuilderRepository { get; protected set; }

        public abstract void Weave(ILGenerator ilGenerator);
    }
}
