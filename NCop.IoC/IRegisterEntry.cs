using NCop.IoC.Fluent;

namespace NCop.IoC
{
    public interface IRegisterEntry
    {
        void Register(IRegistration registration);
    }
}
