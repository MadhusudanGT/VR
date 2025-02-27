using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] SceneName sceneName;
    public void LoadNewScene()
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}

public enum SceneName
{
    Earth,
    Mars,
    Jupiter,
    Mercury,
    Neptune,
    Saturn,
    Uranus,
    Venus,
    HomeScene
}