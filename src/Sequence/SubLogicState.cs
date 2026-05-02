using System.Collections;
using System.Collections.Generic;
using MornLib;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MornLib
{
    internal sealed class SubLogicState : SubBase
    {
        [Inject] private IObjectResolver _resolver;
        [SerializeField] private MornStateMachineInternal _prefab;
        private bool _autoDestroy;
        private MornStateMachineInternal _runtimeInstance;

        [Button("Linkクリア")]
        public void Clear()
        {
            var list = new List<(ExitCode, bool)>();
            SetExitCodeLinks(list);
        }

        [Button("Link再読み込み")]
        public void Reload()
        {
            if (_prefab != null)
            {
                var list = new List<(ExitCode, bool)>();
                foreach (var subState in _prefab.GetComponents<SubStateExitState>())
                {
                    list.Add((subState.ExitCode, subState.AutoDestroy));
                }

                SetExitCodeLinks(list);
            }
        }

        protected override IEnumerator Load()
        {
            if (_runtimeInstance == null)
            {
                _runtimeInstance = _resolver.Instantiate(_prefab, transform);
            }

            _runtimeInstance.playOnStart = true;
            _runtimeInstance.enabled = true;
            _runtimeInstance.Transition(_runtimeInstance.startStateID);
            var provider = _runtimeInstance.gameObject.GetComponent<SubStateController>()
                           ?? _runtimeInstance.gameObject.AddComponent<SubStateController>();
            provider.OnUpdateOnce += Callback;
            provider.NotifyToEnter();
            yield break;
        }

        private void Callback((ExitCode, bool) exitPair)
        {
            _autoDestroy = exitPair.Item2;
            TransitionByExitCode(exitPair.Item1);
        }

        public override void OnStateEnd()
        {
            base.OnStateEnd();
            if (_runtimeInstance != null)
            {
                var provider = _runtimeInstance.gameObject.GetComponent<SubStateController>();
                provider.NotifyExitCompleted();
                if (_autoDestroy)
                {
                    _runtimeInstance.enabled = false;
                    Destroy(_runtimeInstance.gameObject);
                    _runtimeInstance = null;
                }
            }
        }
    }
}
