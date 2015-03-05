using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public interface IPropertyInterceptionAspect<TArg>
    {
        void OnGetValue(PropertyInterceptionArgs<TArg> args);
        void OnSetValue(PropertyInterceptionArgs<TArg> args);
    }
}
