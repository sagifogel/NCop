using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Advices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
    public abstract class AdviceAttribute : Attribute, IAdvice
    {
    }
}
