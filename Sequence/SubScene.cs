using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor.Sequence
{
    internal sealed class SubScene : SubBase
    {
        [SerializeField] private MornSceneObject _scene;

        protected override ExitCode[] GetExitCodes()
        {
            if (string.IsNullOrEmpty(_scene))
            {
                return Array.Empty<ExitCode>();
            }

            var scene = SceneManager.GetSceneByName(_scene);
            if (!scene.IsValid())
            {
                return Array.Empty<ExitCode>();
            }

            var list = new List<ExitCode>();
            list.AddRange(scene.GetRootGameObjects()
                .SelectMany(x => x.GetComponentsInChildren<SubSceneExitImmediate>())
                .Select(x => x.ExitCode));
            return list.ToArray();
        }

        protected override IEnumerator Load()
        {
            yield return SceneManager.LoadSceneAsync(_scene, LoadSceneMode.Additive);
            var scene = SceneManager.GetSceneByName(_scene);
            var sceneObject = new GameObject(nameof(SubSceneExitCodeProvider));
            var provider = sceneObject.AddComponent<SubSceneExitCodeProvider>();
            SceneManager.MoveGameObjectToScene(sceneObject, scene);
            /*while (string.IsNullOrEmpty(provider.ExitCode))
            {
                yield return null;
            }*/
            yield return SceneManager.UnloadSceneAsync(_scene);
            Transition(provider.ExitCode);
        }
    }
}