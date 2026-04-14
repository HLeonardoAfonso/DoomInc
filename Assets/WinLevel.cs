using UnityEngine;

public class WinLevel : MonoBehaviour
{
    public string nextLevelName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;         // Unlock cursor for menu interaction
            SecondMenu.nextLevelName = nextLevelName;       // Set the next level name for the menu to use
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelComplete");
        }
    }
}
