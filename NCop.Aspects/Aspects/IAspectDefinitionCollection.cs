using System.Collections.Generic;

namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinitionCollection : ICollection<IAspectDefinition>
    {
        void AddRange(IEnumerable<IAspectDefinition> range);
        IEnumerable<IAspectDefinition> OrderAspectsByPriority();
    }
}
