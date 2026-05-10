#if USE_ARBOR
using MornLib;
using StateLink = MornLib.StateLink;
using UnityEngine;
using System;

namespace MornLib
{
    [Serializable]
    internal class TransitionState : StateBehaviour
    {
        [SerializeField] private StateLink _nextState;

        public override void OnStateBegin()
        {
            Transition(_nextState);
        }
    }
}
#endif
