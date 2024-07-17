using Arbor;
using UnityEngine;
using UnityEngine.UI;

namespace MornArbor.Tween
{
    public class TweenFadeState : StateBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _duration;
        [SerializeField] private float _endValue;
        [SerializeField] private OutputSlotBool _isEnd;
        [SerializeField] private StateLink _nextState;
        private float _startTime;
        private float _startValue;

        public override void OnStateBegin()
        {
            _startTime = Time.time;
            _startValue = _image.color.a;
            _isEnd.SetValue(false);
        }

        public override void OnStateUpdate()
        {
            var t = Mathf.Clamp01((Time.time - _startTime) / _duration);
            var alpha = Mathf.Lerp(_startValue, _endValue, t);
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
            if (t >= 1)
            {
                Transition(_nextState);
                _isEnd.SetValue(true);
            }
        }
    }
}