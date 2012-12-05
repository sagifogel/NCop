using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public interface IAspectBuilderRepository
    {
        void AddBuilder(Type type, IAspectBuilder builder);
    }
}
