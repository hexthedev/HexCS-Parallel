using System.Threading;
using System.Threading.Tasks;

namespace HexCS.Parallel
{
    /// <summary>
    /// Starts an async that that is awaited, which runs the provided Action repeatedly 
    /// in a while loop until Stopped. It is recommened to use named functions 
    /// rather than lambdas for debugging purposes. 
    /// </summary>
    public class RecurrentAsyncAction : AManagedAsyncTask
    {
        private AsyncAction _action;

        #region Protected API
        /// <inheritdoc>
        protected override async Task PerformAction() => await _action();
        #endregion

        #region Public API
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action">The action to call recurrently. If the action runs forever, 
        /// it will not cancel and will never end</param>
        /// <param name="autoStart"> Start after construction </param>
        public RecurrentAsyncAction(AsyncAction action, bool autoStart = true)
        {
            _action = action;
            if (autoStart) Start();
        }
        #endregion
    }
}
