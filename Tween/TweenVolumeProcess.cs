using Arbor;
using UnityEngine;

namespace MornArbor.Tween
{
    public class TweenVolumeProcess : StateBehaviour, IProcessState
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private float _duration;
        [SerializeField] private float _endValue;
        [SerializeField] private bool _toPlay;
        [SerializeField] private bool _toStop;
        private float _startTime;
        private float _startValue;
        public bool IsActive => Time.time < _startTime + _duration;

        public override void OnStateBegin()
        {
            _startTime = Time.time;
            _startValue = _source.volume;
            if (_toPlay)
            {
                _source.Play();
            }
        }

        public override void OnStateUpdate()
        {
            var t = Mathf.Clamp01((Time.time - _startTime) / _duration);
            _source.volume = Mathf.Lerp(_startValue, _endValue, t);
        }

        public override void OnStateEnd()
        {
            _source.volume = _endValue;
            if (_toStop)
            {
                _source.Stop();
            }
        }
    }
}