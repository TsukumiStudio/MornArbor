using Arbor;
using UnityEditor;

namespace MornArbor
{
    public class ApplicationCloseState : StateBehaviour
    {
        public override void OnStateBegin()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}