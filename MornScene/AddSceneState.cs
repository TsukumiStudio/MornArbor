#if USE_MORN_SCENE
using Arbor;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class AddSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneObject _scene;
        [SerializeField] private StateLink _next;
        private AsyncOperation _task;

        public override void OnStateBegin()
        {
            _task = SceneManager.LoadSceneAsync(_scene, LoadSceneMode.Additive);
        }

        public override void OnStateUpdate()
        {
            if (_task == null || _task.isDone)
                Transition(_next);
        }
    }
}
#endif