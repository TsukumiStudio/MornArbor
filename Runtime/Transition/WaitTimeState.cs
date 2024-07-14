using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class WaitTimeState : StateBehaviour
    {
        [SerializeField] private FlexibleField<float> _waitDuration;
        [SerializeField] private StateLink _next;
        private float _elapsedFrame;

        public override void OnStateBegin()
        {
            _elapsedFrame = 0;
        }

        public override void OnStateUpdate()
        {
            _elapsedFrame += Time.deltaTime;
            if (_elapsedFrame >= _waitDuration.value) Transition(_next);
        }
    }
}