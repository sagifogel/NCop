using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Advices
{
    public interface IAdviceDefinition
    {
        IAdvice Advice { get; }
        MethodInfo AdviceMethod { get; }
    }
}
