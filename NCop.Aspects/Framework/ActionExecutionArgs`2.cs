
namespace NCop.Aspects.Framework
{
    public abstract class ActionExecutionArgs<TArg1, TArg2> : ActionExecutionArgs<TArg1>
    {
        public TArg2 Arg2 { get; set; }
    }
}
