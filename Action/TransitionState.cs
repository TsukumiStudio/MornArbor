using Arbor;
using UnityEngine;

namespace MornArbor
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