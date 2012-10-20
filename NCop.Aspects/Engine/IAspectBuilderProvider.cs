using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IAspectBuilderProvider
    {
        IAspectBuilder GetBuilder(Type type, Func<Type, ILifetimeStrategy> lifetimeStrategyFactory = null);
    }
}
