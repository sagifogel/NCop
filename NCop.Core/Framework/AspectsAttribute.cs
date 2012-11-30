using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Framework
{   
    [AttributeUsage(AttributeTargets.Interface)] 
    public class AspectsAttribute : Attribute
    {
        public AspectsAttribute(params Type[] aspects) {
            Aspects = aspects;
        }

        public Type[] Aspects { get; private set; }
    }
}
