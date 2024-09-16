using System.Collections;
using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubState : SubBase
    {
        [SerializeField] private ArborFSMInternal _prefab;
        [SerializeField] private bool _instantiate;

        protected override void OnValidate()
        {
            if (_prefab != null)
            {
                _prefab.enabled = false;
            }
        }

        protected override IEnumerator Load()
        {
            var subState = _instantiate ? Instantiate(_prefab, transform) : _prefab;
            _prefab.enabled = true;
            subState.Transition(subState.startStateID, TransitionTiming.Immediate);
            var provider = subState.gameObject.AddComponent<SubStateExitCodeProvider>();
            while (string.IsNullOrEmpty(provider.ExitCode))
            {
                yield return null;
            }

            _prefab.enabled = false;
            if (_instantiate)
            {
                Destroy(subState);
            }

            TransitionByExitCode(provider.ExitCode);
        }
    }
}