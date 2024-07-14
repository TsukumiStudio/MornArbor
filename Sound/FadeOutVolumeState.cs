using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class FadeOutVolumeState : StateBehaviour
    {
        [SerializeField] private AudioSource _target;
        [SerializeField] private StateLink _next;
        private float _startTime;
        private float _startVolume;

        public override void OnStateBegin()
        {
            _startTime = Time.unscaledTime;
            _startVolume = _target.volume;
        }

        public override void OnStateUpdate()
        {
            var duration = MornArborGlobalSettings.Instance.FadeOutVolumeDuration;
            var time = Time.unscaledTime - _startTime;
            var rate = Mathf.Clamp01(time / duration);
            _target.volume = Mathf.Lerp(_startVolume, 0f, rate);
            if (time >= duration) Transition(_next);
        }
    }
}