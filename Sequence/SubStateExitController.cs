using System;
using UnityEngine;

namespace MornLib
{
    [AddComponentMenu("")]
    internal sealed class SubStateExitController : MonoBehaviour
    {
        public event Action<(ExitCode, bool)> OnUpdateOnce;
        public event Action OnExitCompleted;

        public void NotifyToExit(ExitCode exitCode, bool autoDestroy)
        {
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