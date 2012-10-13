using NCop.Aspects.Pointcuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IPointcutMatcher
    {
        PointcutMatchCollection Match(Type type);
    }
}
