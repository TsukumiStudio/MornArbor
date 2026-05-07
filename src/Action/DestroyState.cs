#if USE_ARBOR
using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
    [Serializable]
    internal class DestroyState : StateBehaviour
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
#endif
