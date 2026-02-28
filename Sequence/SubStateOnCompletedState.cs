using Arbor;
using UnityEngine;

namespace MornLib
{
    public class SubStateOnCompletedState : StateBehaviour
    {
        [SerializeField] private StateLink _onExit;

        public override void OnStateBegin()
        {
            var provider = GetComponent<SubStateExitController>() ?? gameObject.AddComponent<SubStateExitController>();
            provider.OnExitCompleted += OnExit;
        }

        public override void OnStateEnd()
        {
            var provider = GetComponent<SubStateExitController>() ?? gameObject.AddComponent<SubStateExitController>();
            provider.OnExitCompleted -= OnExit;
        }

        private void OnExit()
        {
            Transition(_onExit);
        }
    }
}