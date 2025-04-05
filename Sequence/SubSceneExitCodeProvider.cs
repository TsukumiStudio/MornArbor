using UnityEngine;

namespace MornArbor
{
    internal sealed class SubSceneExitCodeProvider : MonoBehaviour
    {
        public ExitCode ExitCode { get; private set; }

        public void SetExitCode(ExitCode exitCode)
        {
            ExitCode = exitCode;
        }
    }
}