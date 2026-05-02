using MornLib;
using StateLink = MornLib.Connection;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class WaitFrameRandomState : MornStateBehaviour
#else
    [Serializable]
    internal class WaitFrameRandomState : StateBehaviour
#endif
    {
        [SerializeField] private int _minFrame;
        [SerializeField] private int _maxFrame;
        [SerializeField] private StateLink _next;
        private int _elapsedFrame;
        private int _waitFrame;

        public override void OnStateBegin()
        {
            _elapsedFrame = 0;
            _waitFrame = Random.Range(_minFrame, _maxFrame);
        }

        public override void OnStateUpdate()
        {
            _elapsedFrame++;
            if (_elapsedFrame >= _waitFrame)
            {
                Transition(_next);
            }
        }
    }
}