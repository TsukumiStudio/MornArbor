using Arbor;

namespace MornArbor.States
{
    public class ApplicationCloseState : StateBehaviour
    {
        public override void OnStateBegin()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}