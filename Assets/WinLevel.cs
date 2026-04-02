using UnityEngine;

public class WinLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None; // Unlock cursor for menu interaction
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelComplete");
        }
    }
}
