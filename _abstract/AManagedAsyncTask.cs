using System;
using System.Threading;
using System.Threading.Tasks;
using HexCS.Core;

namespace HexCS.Parallel
{
    /// <inheritdoc />
    public abstract class AManagedAsyncTask : ADisposableManager, IManagedTask
    {
        private CancellationTokenSource _tokenSource;
        private CancellationToken _token;
        private Task _task;

        #region Protected API
        /// <inheritdoc />
        protected override string AccessAfterDisposalMessage { get; } = "BasicRecurrentAction";

        /// <inheritdoc />
        protected override void SetDisposablesToNull()
        {
            _tokenSource = null;
            _task = null;
        }

        /// <summary>
        /// Perform the recurrent action
        /// </summary>
        protected abstract Task PerformAction();
        #endregion

        #region API
        /// <inheritdoc/>
        public bool IsRunning { get; private set; } = false;

        /// <inheritdoc/>
        public void Start()
        {
            ThrowErrorIfDisposed();
            _tokenSource = new CancellationTokenSource();
            RegisterInteralDisposable(_tokenSource);

            _token = _tokenSource.Token;
            _task = Task.Factory.StartNew(RecurrentActionTask, _token);
            IsRunning = true;
        }

        /// <inheritdoc/>
        public void Stop()
        {
            ThrowErrorIfDisposed();
            _tokenSource.Cancel();

            DisposeAndUnregisterDisposable(_tokenSource);
            SetDisposablesToNull();
            IsRunning = false;
        }
        #endregion

        private async Task RecurrentActionTask()
        {
            _token.ThrowIfCancellationRequested();

            while (!_token.IsCancellationRequested)
            {
                await PerformAction();
            }
        }
    }
}
