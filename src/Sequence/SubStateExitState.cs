using Arbor;
using UnityEngine;

namespace MornLib
{
    internal sealed class SubStateExitState : StateBehaviour
    {
        [SerializeField] private ExitCode _exitCode;
        [SerializeField] private bool _autoDestroy = true;
        public ExitCode ExitCode => _exitCode;
        public bool AutoDestroy => _autoDestroy;

        public override void OnStateBegin()
        {
            var provider = GetComponent<SubStateController>();
            if (provider != null)
            {
                provider.NotifyToExit(_exitCode, _autoDestroy);
            }
            else if (_autoDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}