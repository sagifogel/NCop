using System.Collections.Generic;

namespace NCop.Weaving
{
    public interface IPropertyWeaver : IWeaver, IEnumerable<IMethodWeaver>
    {
        bool CanRead { get; }
        bool CanWrite { get; }
        IMethodWeaver GetGetMethod();
        IMethodWeaver GetSetMethod();
    }
}
