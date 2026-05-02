using MornLib;
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal class SetActiveState : MornStateBehaviour
#else
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