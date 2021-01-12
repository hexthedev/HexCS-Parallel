using System;
using System.Collections.Concurrent;

namespace HexCS.Parallel
{
    /// <summary>
    /// An action queue is a thread safe queue with an extra function, 
    /// TryPerformNextAction which handles attempting to dequeue an action
    /// and, if an action exists, running it. 
    /// </summary>
    public class ActionQueue : ConcurrentQueue<Action>
    {
        /// <summary>
        /// Construct ActionQueue
        /// </summary>
        public ActionQueue() : base() { }

        /// <summary>
        /// if an aciton exist and a dequeue suceeds, performs the next action
        /// </summary>
        public bool TryPerformNextAction()
        {
            if (Count > 0 && TryDequeue(out Action action))
            {
                action();
                return true;
            }

            return false;
        }
    }
}
