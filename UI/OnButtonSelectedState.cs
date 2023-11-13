using Arbor;
using UnityEngine;
using UnityEngine.UI;

namespace MornArbor.States
{
    public sealed class OnButtonSelectedState : StateBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private StateLink _nextState;
        private bool _isClicked;

        public override void OnStateBegin()
        {
            _button.onClick.AddListener(OnClicked);
        }

        public override void OnStateUpdate()
        {
            if (!_isClicked)
            {
                return;
            }

            Transition(_nextState);
            _isClicked = false;
        }

        public override void OnStateEnd()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            _isClicked = true;
        }
    }
}