using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    public interface IPropertyExpressionBuilder : IBindingTypeReflectorBuilder
    {
        void SetSetExpression(IAspectExpression aspectExpression);
        void SetGetExpression(IAspectExpression aspectExpression);
    }
}
