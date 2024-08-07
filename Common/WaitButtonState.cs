using Arbor;
using UnityEngine;
using UnityEngine.UI;

namespace MornArbor.Common
{
    public sealed class WaitButtonState : StateBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private StateLink _nextState;

        public override void OnStateBegin()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Transition(_nextState);
        }

        public override void OnStateEnd()
        {
            _button.onClick.RemoveListener(OnClick);
        }
    }
}