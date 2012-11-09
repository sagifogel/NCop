using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Core.Aspects
{
    public interface IAdviceCollection : IReadOnlyCollection<IAdvice>
    {
    }
}
