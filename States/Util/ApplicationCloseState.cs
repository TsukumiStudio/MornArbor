using Arbor;
using UnityEditor;

namespace MornArbor.States
{
    public class ApplicationCloseState : StateBehaviour
    {
        public override void OnStateBegin()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}