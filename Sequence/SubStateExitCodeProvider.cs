using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubStateExitCodeProvider : MonoBehaviour
    {
        public event System.Action<ExitCode> CodeUpdate;
        public ExitCode ExitCode { get; private set; }

        public void SetExitCode(ExitCode exitCode)
        {
            ExitCode = exitCode;
            CodeUpdate?.Invoke(ExitCode);
        }
    }
}