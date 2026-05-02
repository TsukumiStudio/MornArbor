#if USE_MORNSTATE
using MornLib;
#else
using Arbor;
#endif
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    public class SubStateOnCompletedState : MornStateBehaviour
#else
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