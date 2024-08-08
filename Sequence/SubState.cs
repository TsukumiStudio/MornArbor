using System.Collections;
using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubState : SubBase
    {
        [SerializeField] private ArborFSMInternal _prefab;
        [SerializeField] private bool _instantiate;

        protected override IEnumerator Load()
        {
            var subState = _instantiate ? Instantiate(_prefab, transform) : _prefab;
            var provider = subState.gameObject.AddComponent<SubStateExitCodeProvider>();
            while (string.IsNullOrEmpty(provider.ExitCode))
            {
                yield return null;
            }

            if (_instantiate)
            {
                Destroy(subState);
            }

            TransitionByExitCode(provider.ExitCode);
        }
    }
}