using UnityEngine;

public class SecondMenu : MonoBehaviour
{
    public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OpeningScene");
    }

    public void ContinueGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SecondLevel");
    }
}
