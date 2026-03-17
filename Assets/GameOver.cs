using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public void Start()
    {
        SetActive(false);
    }
    
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
