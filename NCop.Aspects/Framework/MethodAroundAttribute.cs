using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class MethodAroundAttribute : AbstractAdviceAttribute
    {
        public MethodAroundAttribute() {

        }
    }
}
