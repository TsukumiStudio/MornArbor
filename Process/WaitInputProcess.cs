#if USE_INPUT_SYSTEM
using UnityEngine;
using UnityEngine.InputSystem;

namespace MornArbor
{
    public class WaitInputProcess : ProcessBase
    {
        [SerializeField] private InputActionReference _inputAction;
        private bool _pressed;

        public override void OnStateBegin()
        {
            _pressed = false;
        }

        public override void OnStateUpdate()
        {
            if (_inputAction.action.IsPressed())
            {
                _pressed = true;
            }
        }

        public override float Progress => _pressed ? 1 : 0;
    }
}
#endif