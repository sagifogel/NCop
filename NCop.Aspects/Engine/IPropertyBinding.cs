
namespace NCop.Aspects.Engine
{
    public interface IPropertyBinding<TInstance, TArg>
    {
        TArg GetValue(ref TInstance instance, IPropertyArg<TArg> arg);
        void SetValue(ref TInstance instance, IPropertyArg<TArg> arg, TArg value);
    }
}
