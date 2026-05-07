using System.Collections;
using System;
using System.Collections.Generic;
#if USE_MORNSTATE
using MornLib;
#else
using Arbor;
#endif
using UnityEngine;
using Object = UnityEngine.Object;
using VContainer;
using VContainer.Unity;

namespace MornLib
{
    [Serializable]
    internal sealed class SubUIState : SubBase
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
                var parent = Object.FindAnyObjectByType<UIParent>();
                if (parent == null)
                {
                    Debug.LogError("SubUIParent not found in scene.");
                    yield break;
                }

                _runtimeInstance = _resolver.Instantiate(_prefab, parent.transform);
            }

            _runtimeInstance.playOnStart = true;
            _runtimeInstance.enabled = true;
            #if USE_MORNSTATE
            _runtimeInstance.Transition(_runtimeInstance.startStateID);
#else
            _runtimeInstance.Transition(_runtimeInstance.startStateID);
#endif
            var provider = _runtimeInstance.gameObject.GetComponent<SubStateController>()
                           ?? _runtimeInstance.gameObject.AddComponent<SubStateController>();
            provider.OnUpdateOnce += Callback;
            provider.NotifyToEnter();
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
