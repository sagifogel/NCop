using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects.Interception
{
    public class SetPropertyInterception : IJointPoint
    {
        public void ProceedSetValue() {
        }

        public object Proceed() {
            throw new NotImplementedException();
        }

        public object Instance {
            get { throw new NotImplementedException(); }
        }
    }
}
