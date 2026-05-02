#if USE_MORNSTATE
using MornLib;
using StateLink = MornLib.Connection;
using System;
#else
using Arbor;
#endif
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    public class SubStateOnCompletedState : MornStateBehaviour
#else
    [Serializable]
    public class SubStateOnCompletedState : StateBehaviour
#endif
    {
        [SerializeField] private StateLink _onExit;

        public override void OnStateBegin()
        {
            var provider = GetComponent<SubStateController>() ?? gameObject.AddComponent<SubStateController>();
            provider.OnExitCompleted += OnExit;
        }

        public override void OnStateEnd()
        {
            var provider = GetComponent<SubStateController>() ?? gameObject.AddComponent<SubStateController>();
            provider.OnExitCompleted -= OnExit;
        }

        private void OnExit()
        {
            Transition(_onExit);
        }
    }
}