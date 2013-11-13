using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class GenericActionExecutionArgs : IAdviceArgs
	{
		public Arguments Arguments { get; protected set; }

        public System.Reflection.MethodBase Method {
            get {
                throw new NotImplementedException();
            }
            protected set {
                throw new NotImplementedException();
            }
        }

        public Exception Exception {
            get {
                throw new NotImplementedException();
            }
            protected set {
                throw new NotImplementedException();
            }
        }

        public FlowBehavior FlowBehavior {
            get {
                throw new NotImplementedException();
            }
            protected set {
                throw new NotImplementedException();
            }
        }
    }
}
