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
