using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubStateExitAction : StateBehaviour
    {
        [SerializeField] private ExitCode _exitCode;

        public override void OnStateBegin()
        {
            foreach (var provider in GetComponentsInChildren<SubStateExitCodeProvider>())
            {
                provider.SetExitCode(_exitCode);
            }
        }
    }
}