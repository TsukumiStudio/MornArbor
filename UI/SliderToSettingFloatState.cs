using Arbor;
using MornSetting;
using UnityEngine;
using UnityEngine.UI;

namespace MornArbor.States
{
    public class SliderToSettingFloatState : StateBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private MornSettingFloatSo _settings;

        public override void OnStateBegin()
        {
            _slider.value = _settings.LoadValue();
            _slider.onValueChanged.AddListener(OnChanged);
        }

        public override void OnStateEnd()
        {
            _slider.onValueChanged.RemoveListener(OnChanged);
        }

        private void OnChanged(float value)
        {
            _settings.SaveValue(value);
        }
    }
}