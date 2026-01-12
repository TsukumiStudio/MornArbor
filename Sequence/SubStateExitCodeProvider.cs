using UnityEngine;

namespace MornLib
{
    internal sealed class SubStateExitCodeProvider : MonoBehaviour
    {
        public event System.Action<(ExitCode, bool)> OnUpdateOnce;

        public void SetExitCode(ExitCode exitCode, bool autoDestroy)
        {
            OnUpdateOnce?.Invoke((exitCode, autoDestroy));
            OnUpdateOnce = null;
        }
    }
}