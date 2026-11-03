using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndOfCycle
{
    [DisallowMultipleComponent]
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        private bool _isSceneValid;
        
        private void Awake()
        {
            if (string.IsNullOrEmpty(_sceneName))
            {
                Debug.LogError("SceneLoader: _sceneName is empty", this);
                return;
            }

            if (!Application.CanStreamedLevelBeLoaded(_sceneName))
            {
                Debug.LogError($"SceneLoader: {_sceneName} cannot be loaded. Check if exists in scene list", this);
                return;
            }
            
            _isSceneValid = true;
        }

        public void LoadScene()
        {
            if (!_isSceneValid)
            {
                return;
            }
            
            SceneManager.LoadScene(_sceneName);
        }
    }
}

