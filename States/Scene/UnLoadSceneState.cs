using Arbor;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor.States
{
    public class UnLoadSceneState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornSceneObject> _scene;
        [SerializeField] private StateLink _next;
        private AsyncOperation _task;

        public override void OnStateBegin()
        {
            _task = SceneManager.UnloadSceneAsync(_scene.value);
        }

        public override void OnStateUpdate()
        {
            if (_task == null || _task.isDone)
            {
                Transition(_next);
            }
        }
    }
}