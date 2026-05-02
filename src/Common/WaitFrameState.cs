using MornLib;
using StateLink = MornLib.Connection;
using UnityEngine;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class WaitFrameState : MornStateBehaviour
#else
    [Serializable]
    internal class WaitFrameState : StateBehaviour
#endif
    {
        [SerializeField] private int _frame;
        [SerializeField] private StateLink _next;
        private int _elapsedFrame;

        public override void OnStateBegin()
        {
            _elapsedFrame = 0;
        }

        public override void OnStateUpdate()
        {
            _elapsedFrame++;
            if (_elapsedFrame >= _frame)
            {
                Transition(_next);
            }
        }
    }
}