using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractArgumentsWeaver<TMember> : IArgumentsWeaver, IArgumentsWeavingSettings where TMember : MemberInfo
    {
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;

        internal AbstractArgumentsWeaver(TMember member, IArgumentsWeavingSettings argumentsWeavingSettings, IAspectWeavingSettings aspectWeavingSettings) {
            Member = member;
            ReturnType = argumentsWeavingSettings.ReturnType;
            AspectType = argumentsWeavingSettings.AspectType;
            Parameters = new Type[argumentsWeavingSettings.Parameters.Length];
            LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            ArgumentType = argumentsWeavingSettings.ArgumentType;
            HasReturnType = argumentsWeavingSettings.HasReturnType;
            MemberType = argumentsWeavingSettings.MemberType;
            argumentsWeavingSettings.Parameters.CopyTo(Parameters, 0);
            this.aspectWeavingSettings = aspectWeavingSettings;
            WeavingSettings = aspectWeavingSettings.WeavingSettings;
            BindingsDependency = argumentsWeavingSettings.BindingsDependency;
        }

        public TMember Member { get; protected set; }

        public bool IsProperty { get; protected set; }
        
        public Type ReturnType { get; protected set; }

        public Type AspectType { get; protected set; }

        public Type ArgumentType { get; protected set; }

        public Type[] Parameters { get; protected set; }

        public bool HasReturnType { get; protected set; }

        public MemberTypes MemberType { get; protected set; }

        public FieldInfo BindingsDependency { get; protected set; }

        public IWeavingSettings WeavingSettings { get; protected set; }

        public ILocalBuilderRepository LocalBuilderRepository { get; protected set; }

        public IByRefArgumentsStoreWeaver ByRefArgumentsStoreWeaver { get; protected set; }

        public abstract void Weave(ILGenerator ilGenerator);
    }
}
