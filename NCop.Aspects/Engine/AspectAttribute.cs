using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public class AspectAttribute : Attribute, IAdviceRepository
    {
        public ILifetimeStrategy LifetimeStrategy {
            get { throw new NotImplementedException(); }
        }

        public void AddAdvice(Advice advice) {
            throw new NotImplementedException();
        }
    }
}
