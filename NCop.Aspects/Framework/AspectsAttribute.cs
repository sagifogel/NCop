using System;

namespace NCop.Aspects.Framework
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
