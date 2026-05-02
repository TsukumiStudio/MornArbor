using MornLib;
using StateLink = MornLib.Connection;
using UnityEngine;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class WaitTimeState : MornStateBehaviour
#else
    [Serializable]
    internal class WaitTimeState : StateBehaviour
#endif
    {
        [SerializeField] private float _waitDuration;
        [SerializeField] private StateLink _next;
        private float _elapsedFrame;

        public override void OnStateBegin()
        {
            _elapsedFrame = 0;
        }

        public override void OnStateUpdate()
        {
            _elapsedFrame += Time.deltaTime;
            if (_elapsedFrame >= _waitDuration) Transition(_next);
        }
    }
}