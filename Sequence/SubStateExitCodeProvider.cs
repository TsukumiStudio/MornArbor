using UnityEngine;

namespace MornArbor
{
    internal sealed class SubStateExitCodeProvider : MonoBehaviour
    {
        public event System.Action<ExitCode> OnUpdateOnce;

        public void SetExitCode(ExitCode exitCode)
        {
            OnUpdateOnce?.Invoke(exitCode);
            OnUpdateOnce = null;
        }
    }
}