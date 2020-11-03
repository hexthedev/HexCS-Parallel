using HexCS.Core;

namespace HexCS.Parallel
{
    /// <summary>
    /// Contains a task that can be Started, Stopped and Disposed
    /// </summary>
    internal interface IManagedTask : IDisposableResource
    {
        /// <summary>
        /// Is task running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Start task
        /// </summary>
        void Start();

        /// <summary>
        /// Stop task
        /// </summary>
        void Stop();
    }
}
