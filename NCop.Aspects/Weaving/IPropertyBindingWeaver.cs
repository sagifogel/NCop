
namespace NCop.Aspects.Weaving
{
    public interface IPropertyBindingWeaver
    {
        bool WeaveGetMethod { get; }
        bool WeaveSetMethod { get; }
    }
}
