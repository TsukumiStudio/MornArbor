#if USE_ARBOR
using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
    [Serializable]
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
#endif
