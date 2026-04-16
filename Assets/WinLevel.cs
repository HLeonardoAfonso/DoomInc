using UnityEngine;

public class WinLevel : MonoBehaviour
{
    public string nextLevelName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;         // Unlock cursor for menu interaction

            if (nextLevelName == "WinGame")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinGame");
            }
            else
            {
                SecondMenu.nextLevelName = nextLevelName;       // Set the next level name for the menu to use
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelComplete");
            }
        }
    }
}
