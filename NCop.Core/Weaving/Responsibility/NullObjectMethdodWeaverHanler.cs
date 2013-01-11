using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public sealed class NullObjectMethdodWeaverHanler : IMethodWeaverHandler
    {
        private static readonly NullObjectMethdodWeaverHanler _instance = new NullObjectMethdodWeaverHanler();

        private NullObjectMethdodWeaverHanler() { }

        public static NullObjectMethdodWeaverHanler Instance {
            get {
                return _instance;
            }
        }

        public IMethodWeaverHandler SetNextHandler(IMethodWeaverHandler nextHanlder) {
            throw new InvalidOperationException("It is impossible to set another handler after NullObjectHanler.");
        }


        public IMethodWeaver Handle(MethodInfo methodInfo) {
            return null;
        }
    }
}
