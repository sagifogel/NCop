using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public abstract class TypeLevelAspectAttribute : AspectAttribute
    {
        public TypeLevelAspectAttribute(Type aspectType)
            : base(aspectType) {
        }
    }
}
