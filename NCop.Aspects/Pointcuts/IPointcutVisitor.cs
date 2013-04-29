using NCop.Aspects.Engine;
using NCop.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Pointcuts
{
    internal interface IPointcutVisitor : IEnumerableProjectionTypeVisitor<IPointcut>
    {
    }
}
