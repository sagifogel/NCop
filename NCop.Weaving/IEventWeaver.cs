using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Weaving
{
    public interface IEventWeaver : IWeaver
    {
        IMethodWeaver GetOnAddMethod();
        IMethodWeaver GetOnRemoveMethod();
    }
}
