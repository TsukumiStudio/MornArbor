using MornLib;
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal class TransitionState : MornStateBehaviour
#else
    internal class TransitionState : StateBehaviour
#endif
    {
        [SerializeField] private StateLink _nextState;

        public override void OnStateBegin()
        {
            Transition(_nextState);
        }
    }
}