using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int initialHealth = 100;
    public int health;
    public TMP_Text healthText;
    public Slider healthBar;

    public GameOverMenu gameOverMenu;
    bool isDead = false;

    void Start()
    {
        health = initialHealth;
        healthBar.minValue = 0;
        healthBar.maxValue = initialHealth;
        healthBar.value = health;
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        Healing(-amount);
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }

    public void Healing(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, initialHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = $"HP: {health}/{initialHealth}";

        if (healthBar != null)
            healthBar.value = health / initialHealth;  // 0 to 1
    }

    void Die()
    {
        //Time.timeScale = 0f; 
        //gameOverMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Unlock cursor for menu interaction
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
