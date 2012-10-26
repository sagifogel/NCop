using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Advices
{
    public interface IAcceptsVisitor<out TResult, TVisitor>
    {
        TResult Accept(TVisitor visitor);
    }
}
