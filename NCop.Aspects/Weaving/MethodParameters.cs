using System;

namespace NCop.Aspects.Weaving
{
    public class MethodParameters
    {
        public Type ReturnType { get;  set; }
        public Type[] Parameters { get; set; }
    }
}
