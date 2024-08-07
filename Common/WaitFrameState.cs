using Arbor;
using UnityEngine;

namespace MornArbor.Common
{
    public class WaitFrameState : StateBehaviour
    {
        [SerializeField] private int _frame;
        [SerializeField] private StateLink _next;
        private int _elapsedFrame;

        public override void OnStateBegin()
        {
            ParticleSystem a;
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