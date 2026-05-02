using MornLib;
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal class WaitTimeState : MornStateBehaviour
#else
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