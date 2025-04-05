using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MornArbor
{
    [Serializable]
    internal struct ExitCode
    {
        [SerializeField] private string _exitCode;

        public ExitCode(string exitCode)
        {
            _exitCode = exitCode;
        }

        public static implicit operator string(ExitCode exitCode)
        {
            return exitCode._exitCode;
        }

        public static implicit operator ExitCode(string exitCode)
        {
            return new ExitCode(exitCode);
        }

        public override string ToString()
        {
            return _exitCode;
        }
    }
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ExitCode))]
    internal sealed class ExitCodePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var exitCode = property.FindPropertyRelative("_exitCode");
            exitCode.stringValue = EditorGUI.TextField(position, label, exitCode.stringValue);
        }
    }
#endif
}