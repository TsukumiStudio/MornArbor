#if USE_ARBOR
using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
    [Serializable]
    internal class SetActiveState : StateBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _isActive;

        public override void OnStateBegin()
        {
            _target.SetActive(_isActive);
        }
    }
}
#endif
