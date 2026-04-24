using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstLevel");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OpeningScene");
    } 
}
