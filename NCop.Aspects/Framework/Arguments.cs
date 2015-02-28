using System.Collections;
using System.Collections.Generic;

namespace NCop.Aspects.Framework
{
    public class Arguments : IReadOnlyCollection<object>
	{
		public static Arguments Empty = new Arguments();
		private readonly List<object> arguments = null;

		private Arguments()
			: this(new List<object>()) {
		}

		public Arguments(IEnumerable<object> arguments) {
			this.arguments = new List<object>(arguments);
		}

		public object GetArgument(int index) {
			return arguments[index];
		}

		public IEnumerator<object> GetEnumerator() {
			return arguments.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

        public int Count {
            get { 
                return arguments.Count; 
            }
        }
    }
}
