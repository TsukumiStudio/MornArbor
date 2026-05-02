using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class DestroyState : MornStateBehaviour
#else
    [Serializable]
    internal class DestroyState : StateBehaviour
#endif
    {
        [SerializeField] private GameObject _target;

        public override void OnStateBegin()
        {
            if (_target == null)
            {
                return;
            }

            Destroy(_target);
        }
    }
}