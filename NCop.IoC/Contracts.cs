using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class Contracts
    {
        public static void RequiersNotInterface(Type type, Func<string> messageFactory = null) {
            if (type.IsInterface) {
                messageFactory = messageFactory ?? new Func<string>(() => string.Empty);
                throw new RegistraionException(messageFactory());
            }
        }
    }
}
