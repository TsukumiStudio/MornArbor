using MornLib;
using StateLink = MornLib.Connection;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class WaitInputState : MornStateBehaviour
#else
    [Serializable]
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