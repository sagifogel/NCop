using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Advices
{
    public interface IAdvice : IAcceptsVisitor<IExpressionReducer, AdviceVisitor>
    {
    }
}
