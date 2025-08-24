using Arbor;
using UnityEngine;

namespace MornArbor
{
    internal sealed class SubStateExitState : StateBehaviour
    {
        [SerializeField] private ExitCode _exitCode;
        [SerializeField] private bool _autoDestroy = true;
        public ExitCode ExitCode => _exitCode;

        public override void OnStateBegin()
        {
            foreach (var provider in GetComponentsInChildren<SubStateExitCodeProvider>())
            {
                provider.SetExitCode(_exitCode, _autoDestroy);
            }
        }
    }
}