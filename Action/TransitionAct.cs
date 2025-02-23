using Arbor;
using UnityEngine;

namespace MornArbor.Action
{
    public class TransitionAct : StateBehaviour
    {
        [SerializeField] private StateLink _nextState;

        public override void OnStateBegin()
        {
            Transition(_nextState);
        }
    }
}