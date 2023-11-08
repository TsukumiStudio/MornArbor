using Arbor;
using UnityEngine;

namespace MornArbor.States
{
    public class WaitFrameState : StateBehaviour
    {
        [SerializeField] private FlexibleField<int> _waitFrame;
        [SerializeField] private StateLink _next;
        private int _elapsedFrame;

        public override void OnStateBegin()
        {
            _elapsedFrame = 0;
        }

        public override void OnStateUpdate()
        {
            _elapsedFrame++;
            if (_elapsedFrame >= _waitFrame.value)
            {
                Transition(_next);
            }
        }
    }
}