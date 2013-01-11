using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public interface IMethodBuilderHandler
    {
        IMethodWeaver Handle(ITypeDefinition typeDefinition);
        IMethodBuilderHandler SetNextHandler(IMethodBuilderHandler nextHanlder);
    }
}
