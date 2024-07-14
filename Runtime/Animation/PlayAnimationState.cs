using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class PlayAnimationState : StateBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _animationClip;
        [SerializeField] private float _duration;
        [SerializeField] private StateLink _nextState;
        private float _startTime;

        public override void OnStateBegin()
        {
            _animator.CrossFadeInFixedTime(_animationClip.name, _duration);
            _startTime = Time.time;
        }

        public override void OnStateUpdate()
        {
            if (Time.time - _startTime > _animationClip.length) Transition(_nextState);
        }
    }
}