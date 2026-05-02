using MornLib;
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal class DestroyState : MornStateBehaviour
#else
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