using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IBindingTypeReflector
	{
		FieldInfo WeavedType { get; }
	}
}
