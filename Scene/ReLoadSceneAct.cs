using Arbor;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class ReLoadSceneAct : StateBehaviour
    {
        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}