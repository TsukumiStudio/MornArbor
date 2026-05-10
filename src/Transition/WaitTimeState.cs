#if USE_ARBOR
using MornLib;
using StateLink = MornLib.StateLink;
using UnityEngine;
using System;

namespace MornLib
{
    [Serializable]
    internal class WaitTimeState : StateBehaviour
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
#endif
