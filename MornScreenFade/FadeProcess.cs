using Arbor;
using MornScreenFade;
using UnityEngine;
using VContainer;

namespace MornArbor.MornScreenFade
{
    public class FadeProcess : StateBehaviour, IProcessState
    {
        [Inject] private IMornScreenFade _screenFade;
        [SerializeField] private float _endValue;
        [SerializeField] private float _duration;
        private float _startTime;
        private float _startValue;
        public bool IsActive => Time.time < _startTime + _duration;

        public override void OnStateBegin()
        {
            _startTime = Time.time;
            _startValue = _screenFade.Value;
        }

        public override void OnStateUpdate()
        {
            var t = Mathf.Clamp01((Time.time - _startTime) / _duration);
            _screenFade.Value = Mathf.Lerp(_startValue, _endValue, t);
        }

        public override void OnStateEnd()
        {
            _screenFade.Value = _endValue;
        }
    }
}