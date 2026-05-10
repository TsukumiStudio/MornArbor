#if USE_ARBOR
using System;
using Arbor;
using MornLib;
using UnityEngine;

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
