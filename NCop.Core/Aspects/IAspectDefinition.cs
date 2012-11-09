using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Core.Aspects
{
    public interface IAspectDefinition
    {
        IAspect Aspect { get; }
        IAdviceCollection Advices { get; }
    }
}
