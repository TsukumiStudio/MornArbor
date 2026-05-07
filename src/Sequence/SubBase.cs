#if USE_ARBOR
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Arbor;
using MornArbor;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    internal abstract class SubBase : StateBehaviour
    {
        [SerializeField, HideInInspector] private List<ExitCodeLink> _exitCodeLinks;
        private IEnumerator _loadCoroutine;

        private StateLink GenerateStateLink(ExitCode exitCode, bool autoDestroy, StateLink old = null)
        {
            return old == null ? new StateLink() : new StateLink { stateID = old.stateID };
        }

        protected void SetExitCodeLinks(List<(ExitCode ExitCode, bool AutoDestroy)> exitCodes)
        {
            foreach (var pair in exitCodes)
            {
                var existing = _exitCodeLinks.FirstOrDefault(x => x.ExitCode.ToString() == pair.ExitCode.ToString());
                if (existing == null)
                {
                    _exitCodeLinks.Add(new ExitCodeLink
                    {
                        ExitCode = pair.ExitCode,
                        Next = GenerateStateLink(pair.ExitCode, pair.AutoDestroy),
                    });
                }
                else
                {
                    existing.Next = GenerateStateLink(pair.ExitCode, pair.AutoDestroy, existing.Next);
                }
            }

            _exitCodeLinks.RemoveAll(x => exitCodes.All(y => y.ExitCode.ToString() != x.ExitCode.ToString()));
            RebuildStateLinkCache();
        }

        public override void OnStateBegin()
        {
            _loadCoroutine = Load();
            StartCoroutine(_loadCoroutine);
        }

        public override void OnStateEnd()
        {
            StopCoroutine(_loadCoroutine);
        }

        protected abstract IEnumerator Load();

        protected void TransitionByExitCode(ExitCode exitCode)
        {
            foreach (var exitCodeLink in _exitCodeLinks)
            {
                if (exitCode == exitCodeLink.ExitCode)
                {
                    Transition(exitCodeLink.Next);
                    return;
                }
            }

            MornArborUtil.LogError($"ExitCode '{exitCode}' not found.");
        }
    }
}
#endif
