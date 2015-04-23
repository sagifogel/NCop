using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public interface IEventBroker<in TDelegate>
    {
        void AddHandler(TDelegate handler);
        void RemoveHandler(TDelegate handler);
    }
}
