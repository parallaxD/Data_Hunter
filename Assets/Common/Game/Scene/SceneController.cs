using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Scene
{
    public class SceneController : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
