using NCop.Aspects.Advices;
using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Advices
{
    public interface IAdviceCollection : IReadOnlyCollection<IAdvice>
    {
    }
}
