using System.Collections;
using System.Collections.Generic;

namespace Aula04
{
    /// <summary>
    /// An experimental enumerator that enumerates from 0 to 9.
    /// </summary>
    /// Using this enumerator in a <c>while</c> loop is equivalent to the
    /// following code:
    /// <code>
    /// for (int i = 0; i < 10; i++)
    /// {
    ///     yield return i;
    /// }
    /// </code>
    public class MyEnumerator : IEnumerator<int>
    {
        /// <summary>
        /// Holds the current value for this enumerator.
        /// </summary>
        public int Current { get; private set; } = Invalid;

        /// <summary>
        /// Explicit interface implementation (non-generic Enumerator). It
        /// simply uses the <see cref="Current">generic version</see>.
        /// </summary>
        object IEnumerator.Current { get { return Current; } }

        /// <summary>
        /// Constant which defines the invalid state of the current value.
        /// </summary>
        public const int Invalid = int.MinValue;

        /// <summary>
        /// Was <see cref="MoveNext()"/> called for the first time already?
        /// </summary>
        private bool isStarted;

        /// <summary>
        /// The maximum value this enumerator will return.
        /// </summary>
        private const int MaxValue = 9;
        
        /// <summary>
        /// We need to implement this method because
        /// <c>IEnumerator&lt;T&gt;</c> extends <c>IDisposable</c>.
        /// </summary>
        public void Dispose()
        {
            // We don't need to do anything here since our enumerator is very
            // simple.
        }

        /// <summary>
        /// Move to the next state, up to the maximum.
        /// </summary>
        /// <returns>
        /// True if there is still another value, false otherwise.
        /// </returns>
        public bool MoveNext()
        {
            if (!isStarted)
            {
                Current = 0;
                isStarted = true;
                return true;
            }
            else if (Current < MaxValue)
            {
                Current++;
                return true;
            }
            else
            {
                Current = Invalid;
                return false;
            }
        }

        /// <summary>
        /// Reset this enumerator.
        /// </summary>
        public void Reset()
        {
            isStarted = false;
        }
    }
}
