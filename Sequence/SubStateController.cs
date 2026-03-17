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
            foreach (var unityEvent in _onEnter)
            {
                unityEvent.Invoke();
            }
        }

        public void NotifyToExit(ExitCode exitCode, bool autoDestroy)
        {
            foreach (var unityEvent in _onExit)
            {
                unityEvent.Invoke();
            }

            OnUpdateOnce?.Invoke((exitCode, autoDestroy));
            OnUpdateOnce = null;
        }

        public void NotifyExitCompleted()
        {
            OnExitCompleted?.Invoke();
            OnExitCompleted = null;
        }
    }
}