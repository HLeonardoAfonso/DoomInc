using UnityEngine;

public class SecondMenu : MonoBehaviour
{
    // Static variable persists between scenes
    public static string nextLevelName = "";

    public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OpeningScene");
    }

    public void ContinueGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
    }
}