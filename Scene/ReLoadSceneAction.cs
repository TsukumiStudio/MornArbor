using Arbor;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class ReLoadSceneAction : StateBehaviour
    {
        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}