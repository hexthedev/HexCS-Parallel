namespace HexCS.Parallel
{
    /// <summary>
    /// A variable wrapper that provides thread safe get and set.
    /// Can also use GetAndClear to clear the variable after get
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadSafeVariable<T>
    {
        private object _variableLock = new object();
        private T _variable = default(T);

        #region API

        /// <summary>
        /// Get or set the value (ThreadSafe)
        /// </summary>
        public T Value
        {
            get
            {
                lock (_variableLock)
                {
                    return _variable;
                }
            }
            set
            {
                lock (_variableLock)
                {
                    _variable = value;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The initial value</param>
        public ThreadSafeVariable(T value = default(T))
        {
            _variable = value;
        }

        /// <summary>
        /// Get the value and reset to default (ThreadSafe)
        /// </summary>
        /// <returns></returns>
        public T GetAndClear()
        {
            lock (_variableLock)
            {
                T variable = _variable;
                _variable = default(T);
                return variable;
            }
        }
        #endregion
    }
}
