using Arbor;
using Cysharp.Threading.Tasks;
using MornAttribute;
using MornScreenFade;
using UnityEngine;
using VContainer;

namespace MornArbor.MornScreenFade
{
    public class FadeClearState : StateBehaviour
    {
        [SerializeField] private bool _isImmediate;
        [SerializeField] private bool _isOverrideDuration;
        [SerializeField, ShowIf(nameof(isOverridingDuration))] private float _duration;
        [SerializeField] private StateLink _next;
        private UniTask _fadeTask;
        private bool isOverridingDuration => _isOverrideDuration;
        [Inject] private IMornScreenFade _transition;

        public override void OnStateBegin()
        {
            _fadeTask = _transition.FadeClearAsync(CancellationTokenOnEnd);
        }

        public override void OnStateUpdate()
        {
            if (_fadeTask.Status != UniTaskStatus.Pending)
                Transition(_next);
        }
    }
}