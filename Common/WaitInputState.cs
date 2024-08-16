#if USE_INPUT_SYSTEM
using Arbor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MornArbor.Common
{
    public class WaitInputState : StateBehaviour
    {
        [SerializeField] private InputActionReference _inputAction;
        [SerializeField] private StateLink _next;

        public override void OnStateUpdate()
        {
            if (_inputAction.action.IsPressed())
            {
                Transition(_next);
            }
        }
    }
}
#endif