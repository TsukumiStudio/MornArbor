using Arbor;
using MornUI;
using UnityEngine;

namespace MornArbor.States
{
    public class MornUIControllerResetFocusState : StateBehaviour
    {
        [SerializeField] private MornUIControllerMono _controller;

        public override void OnStateBegin()
        {
            _controller.ResetFocus();
        }
    }
}