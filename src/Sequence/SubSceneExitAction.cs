using MornLib;
using MornArbor;
using UnityEngine;

namespace MornLib
{
#if USE_MORNSTATE
    internal sealed class SubSceneExitAction : MornStateBehaviour
#else
    internal sealed class SubSceneExitAction : StateBehaviour
#endif
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