using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public abstract class AbstractCompositeMap<TMember> : AbstractMemberMap<TMember>, ICompositeFragmentMap where TMember : MemberInfo
    {
        internal AbstractCompositeMap(Type contractType, Type implementationType, TMember contractMember, TMember implementationMember, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractMember, implementationMember) {
            AspectDefinitions = aspectDefinitions;
            HasAspectDefinitions = aspectDefinitions.IsNotNullOrEmpty();
        }

        public bool HasAspectDefinitions { get; private set; }

        public MethodInfo FragmentMethod { get; protected set; }

        public IAspectDefinitionCollection AspectDefinitions { get; private set; }
    }
}
