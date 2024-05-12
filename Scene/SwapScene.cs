using Arbor;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class SwapSceneState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornSceneObject> _scene;
        private AsyncOperation _task;
        private bool _isUnloadCurrent;

        public override void OnStateBegin()
        {
            _task = SceneManager.LoadSceneAsync(_scene.value, LoadSceneMode.Additive);
            _isUnloadCurrent = false;
        }

        public override void OnStateUpdate()
        {
            if (_task == null || _task.isDone)
            {
                if (_isUnloadCurrent)
                {
                    return;
                }

                SceneManager.UnloadSceneAsync(gameObject.scene);
                _task = null;
                _isUnloadCurrent = true;
            }
        }
    }
}