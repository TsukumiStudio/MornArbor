using System.Collections;
using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubState : SubBase
    {
        [SerializeField] private ArborFSMInternal _prefab;
        [SerializeField] private bool _instantiate;

        private ArborFSMInternal _subState;

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_prefab != null)
            {
                _prefab.enabled = false;
            }
        }

        protected override IEnumerator Load()
        {
            if (_subState != null)
            {
                Debug.LogError("SubState is already loaded.");
                yield break;
            }
            
            _subState = _instantiate ? Instantiate(_prefab, transform) : _prefab;
            _prefab.enabled = true;
            _subState.Transition(_subState.startStateID, TransitionTiming.Immediate);
            var provider = _subState.gameObject.AddComponent<SubStateExitCodeProvider>();
            provider.CodeUpdate += Callback;
            while (string.IsNullOrEmpty(provider.ExitCode))
            {
                yield return null;
            }
            provider.CodeUpdate -= Callback;
        }

        private void Callback(ExitCode exitCode)
        {
            _prefab.enabled = false;
            if (_instantiate)
            {
                Destroy(_subState);
            }

            _subState = null;
            TransitionByExitCode(exitCode);
        }
    }
}