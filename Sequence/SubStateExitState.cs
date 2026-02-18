using Arbor;
using UnityEngine;

namespace MornLib
{
    internal sealed class SubStateExitState : StateBehaviour
    {
        [SerializeField] private ExitCode _exitCode;
        [SerializeField] private bool _autoDestroy = true;
        public ExitCode ExitCode => _exitCode;

        public override void OnStateBegin()
        {
            var provider = GetComponent<SubStateExitController>();
            provider.NotifyToExit(_exitCode, _autoDestroy);
        }
    }
}