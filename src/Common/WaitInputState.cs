#if USE_ARBOR
using MornLib;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace MornLib
{
    [Serializable]
    internal class WaitInputState : StateBehaviour
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
#endif
