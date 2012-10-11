using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PropertyAroundAttribute : AbstractAdviceAttribute
    {
        public bool IsAroundGet { get; private set; }
        public bool IsAroundSet { get; private set; }

        public PropertyAroundAttribute()
            : this(AroundPropertyType.Get | AroundPropertyType.Set) {
        }

        public PropertyAroundAttribute(AroundPropertyType aroundPropertyType) {
            IsAroundGet = (aroundPropertyType & AroundPropertyType.Get) == AroundPropertyType.Get;
            IsAroundSet = (aroundPropertyType & AroundPropertyType.Set) == AroundPropertyType.Set;
        }
    }
}
