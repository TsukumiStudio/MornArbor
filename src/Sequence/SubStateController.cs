#if USE_ARBOR
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MornLib
{
    internal sealed class SubStateController : MonoBehaviour
    {
        [SerializeField] private List<UnityEvent> _onEnter;
        [SerializeField] private List<UnityEvent> _onExit;
        public event Action<(ExitCode, bool)> OnUpdateOnce;
        public event Action OnExitCompleted;

        public void NotifyToEnter()
        {
            if (_onEnter == null) return;
            foreach (var unityEvent in _onEnter)
            {
                unityEvent.Invoke();
            }
        }

        public void NotifyToExit(ExitCode exitCode, bool autoDestroy)
        {
            if (_onExit != null)
            {
                foreach (var unityEvent in _onExit)
                {
                    unityEvent.Invoke();
                }
            }

            if (OnUpdateOnce != null)
            {
                OnUpdateOnce.Invoke((exitCode, autoDestroy));
                OnUpdateOnce = null;
            }
            else if (autoDestroy)
            {
                Destroy(gameObject);
            }
        }

        public void NotifyExitCompleted()
        {
            OnExitCompleted?.Invoke();
            OnExitCompleted = null;
        }
    }
}
#endif
