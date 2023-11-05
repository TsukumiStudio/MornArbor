using Arbor;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor.States
{
    public class LoadSceneState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornSceneObject> _scene;
        [SerializeField] private LoadSceneMode _loadSceneMode;
        [SerializeField] private StateLink _next;
        private AsyncOperation _task;

        public override void OnStateBegin()
        {
            _task = SceneManager.LoadSceneAsync(_scene.value, _loadSceneMode);
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