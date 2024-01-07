using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class PlayAnimationState : StateBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _animationClip;
        [SerializeField] private float _duration;

        public override void OnStateBegin()
        {
            _animator.CrossFadeInFixedTime(_animationClip.name, _duration);
        }
    }
}