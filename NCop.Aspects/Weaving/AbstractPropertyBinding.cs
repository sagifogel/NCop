using NCop.Aspects.Engine;
using System;

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
