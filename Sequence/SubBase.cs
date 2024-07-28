using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal abstract class SubBase : StateBehaviour
    {
        [SerializeField] private List<ExitCodeLink> _exitCodeLinks;
        private IEnumerator _loadCoroutine;

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_exitCodeLinks == null)
            {
                return;
            }

            foreach (var exitCodeLink in _exitCodeLinks)
            {
                var old = exitCodeLink.Next;
                exitCodeLink.Next = new StateLink
                {
                    name = exitCodeLink.ExitCode,
                    stateID = old.stateID,
                    transitionTiming = old.transitionTiming,
                    lineColor = old.lineColor,
                    onTransitionCountChanged = old.onTransitionCountChanged,
                    transitionCount = old.transitionCount,
                };
            }

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

        protected void Transition(ExitCode exitCode)
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