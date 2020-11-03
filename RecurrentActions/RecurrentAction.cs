using System;
using System.Threading;
using System.Threading.Tasks;

namespace HexCS.Parallel
{
    /// <summary>
    /// Starts a Task which runs the provided Action repeatedly 
    /// in while loop until Stopped. It is recommened to use named functions 
    /// rather than lambdas for debugging pruposes. 
    /// </summary>
    public class RecurrentAction : AManagedTask
    {
        private Action _action;

        #region Protected API
        /// <inheritdoc>
        protected override void PerformAction() => _action();
        #endregion

        #region Public API
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action">The action to call recurrently. If the action runs forever, 
        /// it will not cancel and will never end</param>
        /// <param name="autoStart"> Start after construction </param>
        public RecurrentAction(Action action, bool autoStart = true)
        {
            _action = action;
            if (autoStart) Start();
        }
        #endregion
    }
}
