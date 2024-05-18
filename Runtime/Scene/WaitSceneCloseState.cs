using Arbor;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class WaitSceneCloseState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornSceneObject> _scene;
        [SerializeField] private StateLink _next;
        private Scene _loadScene;

        public override void OnStateBegin()
        {
            _loadScene = SceneManager.GetSceneByName(_scene.value);
        }

        public override void OnStateUpdate()
        {
            if (!_loadScene.isLoaded)
            {
                Transition(_next);
            }
        }
    }
}