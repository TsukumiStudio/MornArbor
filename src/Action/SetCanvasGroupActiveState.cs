#if USE_MORNSTATE
using MornLib;
#else
using Arbor;
#endif
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal class SetCanvasGroupActiveState : MornStateBehaviour
#else
    internal class SetCanvasGroupActiveState : StateBehaviour
#endif
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private bool _isActive;

        public override void OnStateBegin()
        {
            _canvasGroup.SetActive(_isActive);
        }
    }
}