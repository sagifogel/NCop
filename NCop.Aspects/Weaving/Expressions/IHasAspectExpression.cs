using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    public interface IHasAspectExpression
    {
        IHasAspectExpression Expression { get; set; }
    }
}
