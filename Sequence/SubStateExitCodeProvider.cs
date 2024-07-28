using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubStateExitCodeProvider : MonoBehaviour
    {
        public ExitCode ExitCode { get; private set; }

        public void SetExitCode(ExitCode exitCode)
        {
            ExitCode = exitCode;
        }
    }
}