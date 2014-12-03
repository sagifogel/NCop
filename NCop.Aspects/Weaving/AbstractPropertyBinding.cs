using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Weaving
{
    public class AbstractPropertyBinding<TInstance, TArg> : IPropertyBinding<TInstance, TArg>
    {
        public virtual TArg GetValue(ref TInstance instance, IPropertyArg<TArg> arg) {
            throw new NotSupportedException();
        }

        public virtual void SetValue(ref TInstance instance, IPropertyArg<TArg> arg, TArg value) {
            throw new NotSupportedException();
        }
    }
}
