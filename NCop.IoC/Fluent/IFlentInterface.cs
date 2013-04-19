using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{   
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFlentInterface
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
    }
}
