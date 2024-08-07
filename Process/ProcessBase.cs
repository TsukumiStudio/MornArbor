using Arbor;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MornArbor.Process
{
    public abstract class ProcessBase : StateBehaviour
    {
        public abstract float Progress { get; }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ProcessBase), true)]
    public sealed class ProcessStateBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var process = (ProcessBase)target;
            var progress = process.Progress;
            var progressText = $"{progress * 100:0.0}%";
            EditorGUI.ProgressBar(EditorGUILayout.GetControlRect(), progress, progressText);
        }
    }
#endif
}