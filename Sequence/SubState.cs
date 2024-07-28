using System;
using System.Collections;
using System.Linq;
using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubState : SubBase
    {
        [SerializeField] private ArborFSMInternal _prefab;

        protected override ExitCode[] GetExitCodes()
        {
            if (_prefab == null)
            {
                return Array.Empty<ExitCode>();
            }

            return _prefab.GetComponentsInChildren<SubStateExitImmediate>()
                .Select(x => x.ExitCode)
                .ToArray();
        }

        protected override IEnumerator Load()
        {
            var subState = Instantiate(_prefab, transform);
            var provider = subState.gameObject.AddComponent<SubStateExitCodeProvider>();
            /*while (string.IsNullOrEmpty(provider.ExitCode))
            {
                yield return null;
            }*/
            Destroy(subState);
            Transition(provider.ExitCode);
            yield break;
        }
    }
}