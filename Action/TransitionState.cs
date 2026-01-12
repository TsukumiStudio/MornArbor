using Arbor;
using UnityEngine;

namespace MornLib
{
    internal class TransitionState : StateBehaviour
    {
        [SerializeField] private StateLink _nextState;

        public override void OnStateBegin()
        {
            Transition(_nextState);
        }
    }
}