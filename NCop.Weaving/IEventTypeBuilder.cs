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
        void SetAddOnMethod(MethodBuilder method);
        void SetRemoveOnMethod(MethodBuilder method);
    }
}
