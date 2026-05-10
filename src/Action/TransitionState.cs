#if USE_ARBOR
using System;
using Arbor;
using MornLib;
using UnityEngine;

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
