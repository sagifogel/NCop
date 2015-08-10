using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;

namespace NCop.Aspects.Tests.Extensions
{
    public static class CollectionAssertExt
    {
        public static void AreAllEqual(params ICollection[] actuals) {
            var first = actuals[0];

            foreach (var actual in actuals.Skip(1)) {
                CollectionAssert.AreEqual(first, actual);
            }
        }
    }
}
