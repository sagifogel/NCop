using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IActionBinding<TInstance>
    {
        void Invoke(ref TInstance instance);
		void Proceed(ref TInstance instance);
    }
}
