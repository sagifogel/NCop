using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IAspectDefinition
    {
        IAspect Aspect { get; }
        IAdviceCollection Advices { get; }
    }
}
