
namespace NCop.IoC
{
    public enum Lifetime
    {
        None,
        PerThread,
        Container,
        Hierarchy,
        HttpRequest,
        HybridRequest
    }
}
