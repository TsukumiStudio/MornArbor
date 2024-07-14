using Arbor;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class ChangeSceneState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornSceneObject> _scene;
        [SerializeField] private StateLink _next;
        private UniTask _task;

        public override void OnStateBegin()
        {
            _task = SceneManager.LoadSceneAsync(_scene.value, LoadSceneMode.Additive).ToUniTask();
        }

        public override void OnStateUpdate()
        {
            if (_task.Status != UniTaskStatus.Pending) Transition(_next);
        }
    }
}