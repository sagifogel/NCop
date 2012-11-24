using NCop.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Core.Engine
{
    public class CompositeMetadata
    {
        public CompositeMetadata(Type compositeType) {
            Type = compositeType;
            Interfaces = compositeType.GetImmediateInterfaces();
            MixinsMap = new MixinsMap(compositeType);
            Concerns = compositeType.GetCustomAttributes<ConcernsAttribute>();
        }

        public Type Type { get; private set; }

        public IEnumerable<Type> Interfaces { get; private set; }

        public IMixinsMap MixinsMap { get; private set; }

        public IEnumerable<ConcernsAttribute> Concerns { get; private set; }
    }
}
