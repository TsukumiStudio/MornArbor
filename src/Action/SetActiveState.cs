using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class SetActiveState : MornStateBehaviour
#else
    [Serializable]
    internal class SetActiveState : StateBehaviour
#endif
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _isActive;

        public override void OnStateBegin()
        {
            _target.SetActive(_isActive);
        }
    }
}