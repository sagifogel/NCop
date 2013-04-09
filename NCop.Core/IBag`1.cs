using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core
{
    public interface IBag<in T>
    {
        void Add(T item);
    }
}
