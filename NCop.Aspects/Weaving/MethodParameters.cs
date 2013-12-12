using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class MethodParameters
    {
        public Type ReturnType { get;  set; }
        public Type[] Parameters { get; set; }
    }
}
