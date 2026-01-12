using System;
using System.Collections.Generic;
using Arbor;
using UnityEditor;
using UnityEngine;

namespace MornLib
{
    internal class MornUGUIControlState : StateBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private MornUGUICanvasInteractableModule _canvasInteractableModule;
        [SerializeField] private MornUGUICanvasFadeModule _canvasFadeModule;
        [SerializeField] private MornUGUIAnimationModule _animationModule;
        [SerializeField] private MornUGUIButtonModule _buttonModule;
        [SerializeField] private MornUGUIFocusModule _focusModule;
        [SerializeField] private MornUGUICancelModule _cancelModule;
        [SerializeField] private MornUGUISoundBlockModule _soundBlockModule;
        private List<MornUGUIStateModuleBase> _modules;
        public CanvasGroup CanvasGroup => _canvasGroup;
        private List<MornUGUIStateModuleBase> Modules => _modules ??= new List<MornUGUIStateModuleBase>
        {
            _soundBlockModule,
            _canvasInteractableModule,
            _canvasFadeModule,
            _animationModule,
            _buttonModule,
            _focusModule,
            _cancelModule,
        };

        public void Execute(Action<MornUGUIStateModuleBase, MornUGUIControlState> action)
        {
            foreach (var module in Modules)
            {
                action(module, this);
            }
        }

        private void Awake()
        {
            Execute((module, parent) => module.OnAwake(parent));
        }

        public override void OnStateBegin()
        {
            Execute((module, parent) => module.OnStateBegin(parent));
        }

        public override void OnStateUpdate()
        {
            Execute((module, parent) => module.OnStateUpdate(parent));
        }

        public override void OnStateEnd()
        {
            Execute((module, parent) => module.OnStateEnd(parent));
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(MornUGUIControlState))]
    public sealed class MornUGUIButtonStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var controlState = (MornUGUIControlState)target;
            if (GUILayout.Button("(Editor)Initialize"))
            {
                controlState.Execute((module, parent) => module.OnEditorInitialize(parent));
                controlState.RebuildStateLinkCache();
                EditorUtility.SetDirty(target);
            }
        }
    }
#endif
}