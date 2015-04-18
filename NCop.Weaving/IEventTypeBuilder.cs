using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Weaving
{
    public interface IEventTypeBuilder
    {
        void SetAddOnMethod(IMethodWeaver method);
        void SetRemoveOnMethod(IMethodWeaver method);
    }
}
