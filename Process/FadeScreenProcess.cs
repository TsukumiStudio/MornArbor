#if USE_MORN_SCREEN_FADE
using MornScreenFade;
using UnityEngine;
using VContainer;

namespace MornArbor.Process
{
    public class FadeScreenProcess : ProcessBase
    {
        [SerializeField] [Range(0, 1f)] private float _endValue;
        [SerializeField] private float _duration = 1;
        [Inject] private IMornScreenFade _screenFade;
        private float _startTime = -1;
        private float _startValue;
        public override float Progress => _startTime < 0 ? 0 :
            _duration > 0 ? Mathf.Clamp01((Time.time - _startTime) / _duration) : 1;

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
    }
}
#endif