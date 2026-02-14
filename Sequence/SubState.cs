using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MornLib
{
    internal sealed class SubState : SubBase
    {
        [SerializeField, Label("動的生成")] private bool _instantiate;
        [SerializeField, HideIf(nameof(_instantiate))] private ArborFSMInternal _instance;
        [SerializeField, ShowIf(nameof(_instantiate))] private ArborFSMInternal _prefab;
        [SerializeField, ShowIf(nameof(_instantiate))] private Transform _parent;
        [SerializeField] private bool _forceAutoDestroy;
        [SerializeField, ReadOnly] private bool _autoDestroy;
        [Inject] private IObjectResolver _resolver;
        private ArborFSMInternal _runtimeInstance;

        public override void OnStateAwake()
        {
            base.OnStateAwake();
            if (_instantiate == false && _instance != null)
            {
                _instance.enabled = false;
                _instance.playOnStart = false;
            }
        }

        [Button("Linkクリア")]
        public void Clear()
        {
            var list = new List<ExitCode>();
            SetExitCodeLinks(list);
        }

        [Button("Link再読み込み")]
        public void Reload()
        {
            var target = _instantiate ? _prefab : _instance;
            if (target != null)
            {
                var list = new List<ExitCode>();
                foreach (var subState in target.GetComponents<SubStateExitState>())
                {
                    list.Add(subState.ExitCode);
                }

                SetExitCodeLinks(list);
            }
        }

        protected override IEnumerator Load()
        {
            if (_runtimeInstance != null)
            {
                Debug.LogError("SubState is already loaded.");
                yield break;
            }

            _runtimeInstance = _instantiate ? _resolver.Instantiate(_prefab, _parent) : _instance;
            _runtimeInstance.playOnStart = true;
            _runtimeInstance.enabled = true;
            _runtimeInstance.Transition(_runtimeInstance.startStateID);
            var provider = _runtimeInstance.gameObject.GetComponent<SubStateExitController>()
                           ?? _runtimeInstance.gameObject.AddComponent<SubStateExitController>();
            provider.OnUpdateOnce += Callback;
        }

        private void Callback((ExitCode, bool) exitPair)
        {
            _autoDestroy = exitPair.Item2;
            TransitionByExitCode(exitPair.Item1);
        }

        public override void OnStateEnd()
        {
            if (_runtimeInstance != null)
            {
                var provider = _runtimeInstance.gameObject.GetComponent<SubStateExitController>();
                provider.NotifyExitCompleted();
                    
                if (_autoDestroy || _forceAutoDestroy)
                {
                    _runtimeInstance.enabled = false;
                }

                if (_instantiate && (_autoDestroy || _forceAutoDestroy))
                {
                    Destroy(_runtimeInstance.gameObject);
                }

                _runtimeInstance = null;
            }
        }
    }
}