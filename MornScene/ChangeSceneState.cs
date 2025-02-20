#if USE_MORN_SCENE
using Arbor;
using Cysharp.Threading.Tasks;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class ChangeSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneObject _scene;

        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(_scene).ToUniTask();
        }
    }
}
#endif