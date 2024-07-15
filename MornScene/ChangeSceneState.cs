using Arbor;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornScene
{
    public class ChangeSceneState : StateBehaviour
    {
        [SerializeField] private FlexibleField<MornSceneObject> _scene;

        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(_scene.value).ToUniTask();
        }
    }
}