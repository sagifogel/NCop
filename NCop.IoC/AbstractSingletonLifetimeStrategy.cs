
namespace NCop.IoC
{
    internal abstract class AbstractSingletonLifetimeStrategy : AbstractLifetimeStrategy
    {
        protected Core.Lib.LazyFactory lazy = new Core.Lib.LazyFactory();
    }
}
