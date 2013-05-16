using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    public abstract class AspectAttribute : Attribute, IAspect
    {
        public int AspectPriority { get; set; }
    }
}
