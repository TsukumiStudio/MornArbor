using Arbor;
using UnityEngine;

namespace MornArbor.States
{
    public class TransitionState : StateBehaviour
    {
        [SerializeField] private StateLink _nextState;

        public override void OnStateBegin()
        {
            Transition(_nextState);
        }
    }
}