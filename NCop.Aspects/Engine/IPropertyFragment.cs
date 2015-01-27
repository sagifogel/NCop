using NCop.Aspects.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    internal interface IPropertyFragment
    {
        IPropertyExpressionBuilder PropertyBuilder { get; }
    }
}
