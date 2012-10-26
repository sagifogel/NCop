using NCop.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class AdviceAttribute : Attribute, IAdvice, IAcceptsVisitor<IAdvice, AdviceVisitor>
    {
        public abstract IAdvice Accept(AdviceVisitor visitor);
    }
}
