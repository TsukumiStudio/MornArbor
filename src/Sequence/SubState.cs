#if USE_ARBOR
using System;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using MornStateMachineInternal = Arbor.ArborFSMInternal;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    internal sealed class SubState : SubBase
    {
        [Inject] private IObjectResolver _resolver;
        [SerializeField, Label("動的生成")] private bool _instantiate;
        [SerializeField, HideIf(nameof(_instantiate))] private MornStateMachineInternal _instance;
        [SerializeField, ShowIf(nameof(_instantiate))] private MornStateMachineInternal _prefab;
        [SerializeField, ShowIf(nameof(_instantiate))] private Transform _parent;
        [SerializeField] private bool _forceAutoDestroy;
        private bool _autoDestroy;
        private MornStateMachineInternal _runtimeInstance;

        public void Awake()
        {
            if (_instantiate == false && _instance != null)
            {
                _instance.enabled = false;
                _instance.playOnStart = false;
            }
        }

        [Button("Linkクリア")]
        public void Clear()
        {
            var list = new List<(ExitCode, bool)>();
            SetExitCodeLinks(list);
        }

        [Button("Link再読み込み")]
        public void Reload()
        {
            var target = _instantiate ? _prefab : _instance;
            if (target != null)
            {
                var list = new List<(ExitCode, bool)>();
                foreach (var subState in target.GetComponents<SubStateExitState>())
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
                _runtimeInstance = _instantiate ? _resolver.Instantiate(_prefab, _parent) : _instance;
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
                if (_autoDestroy || _forceAutoDestroy)
                {
                    _runtimeInstance.enabled = false;
                    if (_instantiate)
                    {
                        Destroy(_runtimeInstance.gameObject);
                    }

                    _runtimeInstance = null;
                }
            }
        }
    }
}
#endif
