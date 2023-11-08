using Arbor;
using MornUI;
using UnityEngine;

namespace MornArbor.States
{
    public class MornUIPanelResetFocusState : StateBehaviour
    {
        [SerializeField] private MornUIPanelMono _panel;

        public override void OnStateBegin()
        {
            _panel.ResetFocus();
        }
    }
}