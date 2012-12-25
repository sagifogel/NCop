using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;

namespace NCop.Composite.Engine
{
    public class CompositeMetadata
    {
        public CompositeMetadata(Type compositeType) {
            Type = compositeType;
            Interfaces = compositeType.GetImmediateInterfaces();
            MixinsMap = new MixinsMap(compositeType);
            AspectsMap = new AspectsMap(compositeType);
        }

        public Type Type { get; private set; }

        public IMixinsMap MixinsMap { get; private set; }

        public IAspectsMap AspectsMap { get; private set; }

        public IEnumerable<Type> Interfaces { get; private set; }
    }
}
