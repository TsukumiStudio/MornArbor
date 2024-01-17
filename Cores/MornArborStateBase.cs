using System;
using System.Collections.Generic;
using System.Threading;
using Arbor;
using UniRx;
using UnityEngine.Events;

namespace MornArbor
{
    public static class UnityEventEx
    {
        public static UnityEvent With(this UnityEvent unityEvent, MornArborStateBase stateBase)
        {
            stateBase.With(unityEvent);
            return unityEvent;
        }
    }

    public abstract class MornArborStateBase : StateBehaviour
    {
        private CompositeDisposable _disposable;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly List<UnityEvent> _eventList = new();
        protected ICollection<IDisposable> StateDisposable => _disposable;
        protected CancellationToken StateToken => _cancellationTokenSource?.Token ?? CancellationToken.None;

        public void With(UnityEvent unityEvent)
        {
            _eventList.Add(unityEvent);
        }

        public override sealed void OnStateBegin()
        {
            _disposable = new CompositeDisposable();
            _cancellationTokenSource = new CancellationTokenSource();
            _eventList.Clear();
            OnStateBeginImpl();
        }

        public override sealed void OnStateUpdate()
        {
            OnStateUpdateImpl();
        }

        public override sealed void OnStateEnd()
        {
            OnStateEndImpl();
            Dispose();
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void Dispose()
        {
            foreach (var unityEvent in _eventList)
            {
                unityEvent.RemoveAllListeners();
            }

            _eventList.Clear();
            _disposable?.Dispose();
            _disposable = null;
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        protected virtual void OnStateBeginImpl()
        {
        }

        protected virtual void OnStateUpdateImpl()
        {
        }

        protected virtual void OnStateEndImpl()
        {
        }
    }
}