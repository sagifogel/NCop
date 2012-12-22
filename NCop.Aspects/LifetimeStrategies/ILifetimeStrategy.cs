using NCop.Aspects.Aspects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.LifetimeStrategies
{
    public interface ILifetimeStrategy 
    {
        IAspect Aspect { get; }
    }
}
