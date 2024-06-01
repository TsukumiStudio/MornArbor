using Arbor;
using MornUI;
using UnityEngine;

namespace MornArbor
{
    public class MornUIResendFocusState : StateBehaviour
    {
        [SerializeField] private MornUIControllerMono _controller;

        public override void OnStateBegin()
        {
            _controller.ResendFocus();
        }
    }
}