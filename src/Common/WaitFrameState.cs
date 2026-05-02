using MornLib;
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal class WaitFrameState : MornStateBehaviour
#else
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