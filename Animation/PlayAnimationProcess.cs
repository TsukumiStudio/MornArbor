using Arbor;
using UnityEngine;

namespace MornArbor.Animation
{
    public class PlayAnimationProcess : StateBehaviour, IProcessState
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _animationClip;
        private float _startTime;
        public bool IsActive => Time.time < _startTime + _animationClip.length;

        public override void OnStateBegin()
        {
            _animator.CrossFadeInFixedTime(_animationClip.name, 0);
            _startTime = Time.time;
        }
    }
}