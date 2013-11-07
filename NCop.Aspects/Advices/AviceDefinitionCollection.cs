using NCop.Core;
using NCop.Core.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Advices
{
    public class AdviceDefinitionCollection : Collection<IAdviceDefinition>, IAdviceDefinitionCollection
    {
    }
}
