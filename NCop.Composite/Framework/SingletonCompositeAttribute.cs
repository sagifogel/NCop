using NCop.Composite.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Framework
{
    public class SingletonCompositeAttribute : CompositeAttribute
    {
        public SingletonCompositeAttribute(Type castAs = null)
            : base(castAs) {
        }
    }
}
