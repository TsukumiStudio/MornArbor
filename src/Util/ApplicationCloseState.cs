using MornLib;
using UnityEditor;

namespace MornLib
{
#if USE_MORNSTATE
    internal class ApplicationCloseState : MornStateBehaviour
#else
    internal class ApplicationCloseState : StateBehaviour
#endif
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