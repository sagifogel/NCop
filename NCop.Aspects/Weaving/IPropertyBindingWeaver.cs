using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    public interface IPropertyBindingWeaver
    {
        bool WeaveGetMethod { get; }
        bool WeaveSetMethod { get; }
    }
}
