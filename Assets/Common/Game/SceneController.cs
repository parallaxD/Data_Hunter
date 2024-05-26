using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Common
{
    public class SceneController : MonoBehaviour
    {
        private AsyncOperation asyncOperation;

        public bool IsSceneLoaded { get { return asyncOperation.isDone; } }

        public KeyCode _keyToLoad = KeyCode.G;

        [SerializeField] private ScreenTextManager _screenTextManager;

        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }


        public void LoadSceneAsync(string sceneName)
        {
            asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;
        }

        public void ActivateScene()
        {
            asyncOperation.allowSceneActivation = true;
        }

    }
}
