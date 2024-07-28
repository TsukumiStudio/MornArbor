using Arbor;
using UnityEngine;

namespace MornArbor.Sequence
{
    internal sealed class SubSceneExitImmediate : StateBehaviour
    {
        [SerializeField] private ExitCode _exitCode;
        public ExitCode ExitCode => _exitCode;
        public bool IsActive { get; } = true;

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