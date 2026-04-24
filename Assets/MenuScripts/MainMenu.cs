using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstLevel");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
