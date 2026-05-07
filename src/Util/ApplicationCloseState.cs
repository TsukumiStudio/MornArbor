using Arbor;
﻿using MornLib;
using UnityEditor;
using System;

namespace MornLib
{
    [Serializable]
    internal class ApplicationCloseState : StateBehaviour
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