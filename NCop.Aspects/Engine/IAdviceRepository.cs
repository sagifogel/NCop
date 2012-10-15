using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IAdviceRepository
    {
        void AddAdvice(Advice advice);
    }
}
