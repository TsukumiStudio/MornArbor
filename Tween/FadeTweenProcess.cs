using Arbor;
using MornEase;
using UnityEngine;

namespace MornArbor.Tween
{
    public class FadeTweenProcess : ProcessBase
    {
        [SerializeField] private CanvasGroup _target;
        [SerializeField] private float _duration;
        [SerializeField] private float _endValue;
        [SerializeField] private MornEaseType _easeType;
        [SerializeField] private StateLink _nextState;
        private float _startTime;
        private float _startValue;
        public override float Progress => Mathf.Clamp01((Time.time - _startTime) / _duration);

        public override void OnStateBegin()
        {
            _startTime = Time.time;
            _startValue = _target.alpha;
        }

        public override void OnStateUpdate()
        {
            var t = Mathf.Clamp01((Time.time - _startTime) / _duration);
            t = t.Ease(_easeType);
            var value = Mathf.Lerp(_startValue, _endValue, t);
            _target.alpha = value;
            if (t >= 1)
            {
                Transition(_nextState);
            }
        }
    }
}