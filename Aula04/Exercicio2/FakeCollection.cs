using System.Collections;
using System.Collections.Generic;

namespace Aula04
{
    /// <summary>
    /// A faken collection class which returns an instance of
    /// <see cref="MyEnumerator"/> when someone tries to iterate over it.
    /// </summary>
    public class FakeCollection : IEnumerable<int>
    {
        /// <summary>
        /// Method required by the <c>IEnumerable&lt;T&gt;</c> interface.
        /// </summary>
        /// <returns>An instance of <see cref="MyEnumerator"/>.</returns>
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator();
        }

        /// <summary>
        /// Method required by the <c>IEnumerable</c> interface.
        /// </summary>
        /// <returns>
        /// Returns whatever <see cref="GetEnumerator()"/> returns.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
