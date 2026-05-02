using MornLib;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MornLib
{
#if USE_MORNSTATE
    internal class WaitInputState : MornStateBehaviour
#else
    internal class WaitInputState : StateBehaviour
#endif
    {
        [SerializeField] private InputActionReference _inputAction;
        [SerializeField] private StateLink _next;

        public override void OnStateUpdate()
        {
            if (_inputAction.action.WasPerformedThisFrame())
            {
                Transition(_next);
            }
        }
    }
}