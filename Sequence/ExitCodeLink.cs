using System;
using Arbor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MornArbor.Sequence
{
    [Serializable]
    internal sealed class ExitCodeLink
    {
        public ExitCode ExitCode;
        public StateLink Next;
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ExitCodeLink))]
    internal sealed class ExitCodeLinkDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var exitCodeProperty = property.FindPropertyRelative("ExitCode");
            var exitCode = ((ExitCode)exitCodeProperty.boxedValue).ToString();
            if (!string.IsNullOrEmpty(exitCode))
            {
                label.text = exitCode;
            }

            EditorGUI.PropertyField(position, property.FindPropertyRelative("ExitCode"), label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
#endif
}