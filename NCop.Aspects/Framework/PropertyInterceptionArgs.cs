using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class PropertyInterceptionArgs<TArg> : AbstractPropertyAdviceArgs, IPropertyInterceptionArgs
    {
        public TArg Value { get; set; }
        public abstract void ProceedSetValue();
        public abstract void ProceedGetValue();
        public abstract TArg GetCurrentValue();
        public abstract void SetNewValue(TArg value);
    }
}
