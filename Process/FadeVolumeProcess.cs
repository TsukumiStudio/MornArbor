using UnityEngine;

namespace MornArbor.Process
{
    public class FadeVolumeProcess : ProcessBase
    {
        [SerializeField] [Range(0, 1f)] private float _endValue;
        [SerializeField] private float _duration = 1;
        [SerializeField] private AudioSource _source;
        private float _startTime;
        private float _startValue;
        public override float Progress => _duration > 0 ? Mathf.Clamp01((Time.time - _startTime) / _duration) : 1;

        public override void OnStateBegin()
        {
            _startTime = Time.time;
            _startValue = _source.volume;
        }

        public override void OnStateUpdate()
        {
            var t = Mathf.Clamp01((Time.time - _startTime) / _duration);
            _source.volume = Mathf.Lerp(_startValue, _endValue, t);
        }

        public override void OnStateEnd()
        {
            _source.volume = _endValue;
        }
    }
}