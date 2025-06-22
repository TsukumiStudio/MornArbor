using Arbor;
using UnityEngine;

namespace MornArbor
{
    internal sealed class SubStateExitState : StateBehaviour
    {
        [SerializeField] private ExitCode _exitCode;
        public ExitCode ExitCode => _exitCode;

        public override void OnStateBegin()
        {
            foreach (var provider in GetComponentsInChildren<SubStateExitCodeProvider>())
            {
                provider.SetExitCode(_exitCode);
            }
        }
    }
}