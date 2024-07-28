using System.Collections;
using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubState : SubBase
    {
        [SerializeField] private ArborFSMInternal _prefab;

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