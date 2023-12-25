using System;
using Arbor;
using UnityEngine;
using UnityEngine.UI;

namespace MornArbor.States
{
    public sealed class OnButtonState : StateBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private StateLink _nextState;
        private IDisposable _disposable;

        public override void OnStateBegin()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _button.onClick.RemoveListener(OnClick);
            Transition(_nextState);
        }
    }
}