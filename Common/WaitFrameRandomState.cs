using Arbor;
using UnityEngine;

namespace MornArbor.Common
{
    public class WaitFrameRandomState : StateBehaviour
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