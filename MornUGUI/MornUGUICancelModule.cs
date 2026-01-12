using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MornLib
{
    [Serializable]
    internal class MornUGUICancelModule : MornUGUIStateModuleBase
    {
        [SerializeField, Label("有効化")] private bool _isActive;
        [SerializeField, ShowIf(nameof(IsActive)), Label("フォーカス対象")] private Selectable _target;
        private bool IsActive => _isActive;

        public override void Initialize(MornUGUIControlState parent)
        {
        }

        public override void OnStateUpdate()
        {
            if (!_isActive || _target == null) return;
            var current = EventSystem.current.currentSelectedGameObject;
            // AutoFocusModule側でまずはフォーカスが合うため、nullの時は処理しない
            if (current == null) return;
            if (MornUGUIGlobal.I.InputCancel.WasPerformedThisFrame())
            {
                if (current != _target.gameObject)
                {
                    EventSystem.current.SetSelectedGameObject(_target.gameObject);
                }
                else
                {
                    ExecuteEvents.Execute(
                        _target.gameObject,
                        new BaseEventData(EventSystem.current),
                        ExecuteEvents.submitHandler);
                }
            }
        }
    }
}