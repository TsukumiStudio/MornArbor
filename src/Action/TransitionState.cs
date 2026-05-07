using MornLib;
using StateLink = MornLib.Connection;
using UnityEngine;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class TransitionState : MornStateBehaviour
#else
    [Serializable]
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