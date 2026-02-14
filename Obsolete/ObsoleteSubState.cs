using System;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using MornArbor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MornLib
{
    [Obsolete("SubStateへ移行")]
    internal sealed class ObsoleteSubState : SubBase
    {
        [SerializeField] private ArborFSMInternal _prefab;
        [SerializeField] private bool _instantiate;
        [SerializeField, ShowIf(nameof(_instantiate))] private Transform _parent;
        [SerializeField, ReadOnly] private bool _autoDestroy;
        [Inject] private IObjectResolver _resolver;
        private ArborFSMInternal _instance;

        public override void OnStateAwake()
        {
            base.OnStateAwake();
            if (_instantiate == false && _prefab != null)
            {
                _prefab.enabled = false;
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
            if (_prefab != null)
            {
                var list = new List<ExitCode>();
                foreach (var subState in _prefab.GetComponents<SubStateExitState>())
                {
                    list.Add(subState.ExitCode);
                }

                SetExitCodeLinks(list);
            }
        }

        protected override IEnumerator Load()
        {
            if (_instance != null)
            {
                Debug.LogError("SubState is already loaded.");
                yield break;
            }

            _instance = _instantiate ? _resolver.Instantiate(_prefab, _parent) : _prefab;
            _instance.enabled = true;
            _instance.Transition(_instance.startStateID, TransitionTiming.Immediate);
            var provider = _instance.gameObject.GetComponent<SubStateExitController>()
                           ?? _instance.gameObject.AddComponent<SubStateExitController>();
            provider.OnUpdateOnce += Callback;
        }

        private void Callback((ExitCode, bool) exitPair)
        {
            _autoDestroy = exitPair.Item2;
            TransitionByExitCode(exitPair.Item1);
        }

        public override void OnStateEnd()
        {
            if (_instance != null)
            {
                if (_autoDestroy)
                {
                    _instance.enabled = false;
                }
                
                if (_instantiate && _autoDestroy)
                {
                    Destroy(_instance.gameObject);
                }

                _instance = null;
            }
        }
    }
}