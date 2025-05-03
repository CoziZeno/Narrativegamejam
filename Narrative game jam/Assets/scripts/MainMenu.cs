using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndexToLoad = 1; // Set this to your game scene's index in Build Settings

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting..."); // Only visible in the editor
    }
}
