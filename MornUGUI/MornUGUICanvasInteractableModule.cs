using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    internal class MornUGUICanvasInteractableModule : MornUGUIStateModuleBase
    {
        [SerializeField] private bool _ignore;

        public override void OnAwake(MornUGUIControlState parent)
        {
            if (_ignore)
            {
                return;
            }

            parent.CanvasGroup.interactable = false;
            parent.CanvasGroup.blocksRaycasts = false;
        }

        public override void OnStateBegin(MornUGUIControlState parent)
        {
            if (_ignore)
            {
                return;
            }

            parent.CanvasGroup.interactable = true;
            parent.CanvasGroup.blocksRaycasts = true;
        }

        public override void OnStateEnd(MornUGUIControlState parent)
        {
            if (_ignore)
            {
                return;
            }

            parent.CanvasGroup.interactable = false;
            parent.CanvasGroup.blocksRaycasts = false;
        }
    }
}