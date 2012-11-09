using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Framework
{   
    [AttributeUsage(AttributeTargets.Interface)] 
    public class ConcernAttribute : Attribute
    {
        public ConcernAttribute(params Type[] concerns) {

        }
    }
}
