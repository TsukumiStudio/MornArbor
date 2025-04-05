using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arbor;
using UnityEngine;

namespace MornArbor
{
    internal abstract class SubBase : StateBehaviour
    {
        [SerializeField] private List<ExitCodeLink> _exitCodeLinks;
        private IEnumerator _loadCoroutine;

        private StateLink GenerateStateLink(ExitCode exitCode, StateLink old = null)
        {
            if (old == null)
            {
                var result = new StateLink
                {
                    name = exitCode,
                };
                return result;
            }

            return new StateLink
            {
                name = exitCode,
                stateID = old.stateID,
                transitionTiming = old.transitionTiming,
                lineColor = old.lineColor,
                onTransitionCountChanged = old.onTransitionCountChanged,
                transitionCount = old.transitionCount,
            };
        }

        protected void SetExitCodeLinks(List<ExitCode> exitCodes)
        {
            foreach (var exitCode in exitCodes)
            {
                if (_exitCodeLinks.All(x => x.ExitCode.ToString() != exitCode.ToString()))
                {
                    _exitCodeLinks.Add(
                        new ExitCodeLink
                        {
                            ExitCode = exitCode,
                            Next = GenerateStateLink(exitCode),
                        });
                }
            }

            _exitCodeLinks.RemoveAll(x => exitCodes.All(y => y.ToString() != x.ExitCode.ToString()));
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