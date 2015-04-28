using NCop.Core.Extensions;
using System.Reflection;

namespace NCop.Core
{
    public static class EventComparer
    {
        public static bool IsMatchedTo(this EventInfo firstEvent, EventInfo secondEvent) {
            if (firstEvent.IsNull() || !firstEvent.Name.Equals(secondEvent.Name) || firstEvent.EventHandlerType != secondEvent.EventHandlerType) {
                return false;
            }

            return firstEvent.GetAddMethod().IsMatchedTo(secondEvent.GetAddMethod());
        }
    }
}
