#if USE_ARBOR
using System;
using Arbor;
using MornArbor;
using MornLib;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    internal sealed class SubSceneExitAction : StateBehaviour
    {
        [SerializeField] private ExitCode _exitCode;

        public override void OnStateBegin()
        {
            var scene = gameObject.scene;
            var roots = scene.GetRootGameObjects();
            foreach (var root in roots)
            {
                foreach (var provider in root.GetComponentsInChildren<SubSceneExitCodeProvider>())
                {
                    provider.SetExitCode(_exitCode);
                }
            }
        }
    }
}
#endif
