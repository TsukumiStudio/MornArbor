using MornLib;
using UnityEngine;

namespace MornLib
{
    internal class SetCanvasGroupActiveState : StateBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private bool _isActive;

        public override void OnStateBegin()
        {
            _canvasGroup.SetActive(_isActive);
        }
    }
}