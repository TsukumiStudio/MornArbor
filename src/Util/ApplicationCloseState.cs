using MornLib;
using UnityEditor;
using System;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class ApplicationCloseState : MornStateBehaviour
#else
    [Serializable]
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