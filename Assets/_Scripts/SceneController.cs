using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script changes scenes.
/// </summary>
public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}