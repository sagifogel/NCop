using NCop.Aspects.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Aspects.Pointcuts
{
    public class PointcutCollection : Collection<IPointcut>, IPointcutCollection
    {
        public PointcutCollection(IEnumerable<IPointcut> pointcuts) : base(pointcuts) { }
    }
}
