using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public class PropertyInterceptionArgsImpl<TArg1> : PropertyInterceptionArgs<TArg1>
    {
        public override void ProceedSetValue() {
            throw new NotImplementedException();
        }

        public override void ProceedGetValue() {
            throw new NotImplementedException();
        }

        public override TArg1 GetCurrentValue() {
            throw new NotImplementedException();
        }

        public override TArg1 SetNewValue(TArg1 value) {
            throw new NotImplementedException();
        }
    }
}
