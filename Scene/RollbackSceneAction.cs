using Arbor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    public class RollbackSceneAction : StateBehaviour
    {
        [SerializeField] private string _key;
        [SerializeField] private LoadSceneMode _loadSceneMode;

        public override void OnStateBegin()
        {
            if (MornArborService.I.TryGetRollbackScene(_key, out var sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName, _loadSceneMode);
            }
            else
            {
                MornArborUtil.LogError($"RollbackSceneAction: Not found scene key: {_key}");
            }
        }
    }
}