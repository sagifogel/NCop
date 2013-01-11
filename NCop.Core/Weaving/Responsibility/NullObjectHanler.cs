using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving.Responsibility
{
    public sealed class NullObjectHanler : IMethodBuilderHandler
    {
        private static readonly NullObjectHanler _instance = new NullObjectHanler();

        private NullObjectHanler() { }

        public static NullObjectHanler Instance {
            get {
                return _instance;
            }
        }

        public IMethodBuilderHandler SetNextHandler(IMethodBuilderHandler nextHanlder) {
            throw new InvalidOperationException("It is impossible to set another handler after NullObjectHanler.");
        }


        public IMethodWeaver Handle(ITypeDefinition typeDefinition) {
            return null;
        }
    }
}
