using Arbor;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class LoadAndWaitCloseSceneState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornSceneObject> _scene;
        [SerializeField] private StateLink _next;
        private AsyncOperation _loadTask;
        private Scene _loadScene;

        public override void OnStateBegin()
        {
            _loadTask = SceneManager.LoadSceneAsync(_scene.value, LoadSceneMode.Additive);
            _loadScene = SceneManager.GetSceneByName(_scene.value);
        }

        public override void OnStateUpdate()
        {
            if (_loadTask == null || _loadTask.isDone)
            {
                if (!_loadScene.isLoaded)
                {
                    Transition(_next);
                }
            }
        }
    }
}