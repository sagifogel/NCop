using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IAcceptsVisitor<out TResult, TVisitor, in S>
    {
        TResult Accept(TVisitor visitor, S value);
    }
}
