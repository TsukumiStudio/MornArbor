using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class SetCanvasGroupActiveState : StateBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private bool _isActive;

        public override void OnStateBegin()
        {
            _canvasGroup.interactable = _isActive;
            _canvasGroup.blocksRaycasts = _isActive;
        }
    }
}