using Arbor;
using UnityEditor;
using UnityEngine;

namespace MornArbor
{
    [CustomEditor(typeof(SubState))]
    public sealed class SubStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var subModuleProperty = serializedObject.FindProperty("subModule");
            if (subModuleProperty == null) return;

            var subModule = subModuleProperty.objectReferenceValue as GameObject;
            if (subModule == null) return;

            var arbor = subModule.GetComponent<ArborFSMInternal>();
            if (arbor == null) return;

            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("StateExitNames");

            // Indent
            EditorGUI.indentLevel++;
            foreach (var stateExit in arbor.GetComponents<StateExit>())
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(EditorGUI.indentLevel * 10);
                GUILayout.Label(stateExit.ExitFlagName);
                if (GUILayout.Button("Copy", GUILayout.Width(40)))
                    EditorGUIUtility.systemCopyBuffer = stateExit.ExitFlagName;

                GUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
            GUILayout.EndVertical();
        }
    }
}