using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Framework
{   
    [AttributeUsage(AttributeTargets.Interface)] 
    public class ConcernsAttribute : Attribute
    {
        public ConcernsAttribute(params Type[] concerns) {

        }
    }
}
