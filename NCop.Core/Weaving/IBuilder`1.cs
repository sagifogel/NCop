using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
