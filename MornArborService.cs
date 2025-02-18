using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor
{
    internal sealed class MornArborService : MonoBehaviour
    {
        [SerializeField] private List<string> _rollbackKeys = new();
        [SerializeField] private List<string> _rollbackSceneNames = new();
        private static MornArborService _instance;
        public static MornArborService I
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<MornArborService>(FindObjectsInactive.Include);
                }
                
                if (_instance == null)
                {
                    var go = new GameObject(nameof(MornArborService));
                    _instance = go.AddComponent<MornArborService>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        public void RegisterRollbackScene(string key, Scene scene)
        {
            _rollbackKeys.Add(key);
            _rollbackSceneNames.Add(scene.name);
        }
        
        public bool TryGetRollbackScene(string key, out string sceneName)
        {
            var index = _rollbackKeys.IndexOf(key);
            if (index == -1)
            {
                sceneName = default;
                return false;
            }

            sceneName = _rollbackSceneNames[index];
            return true;
        }
    }
}