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
        public abstract void ProceedSetValue();
        public abstract void ProceedGetValue();
        public abstract TArg GetCurrentValue();
        public abstract TArg SetNewValue(TArg value);
    }
}
