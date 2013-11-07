using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Advices
{
    public interface IAdviceDefinitionCollection : IReadOnlyCollection<IAdviceDefinition>
    {
    }
}
