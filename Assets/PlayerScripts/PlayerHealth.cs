using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int initialHealth = 100;
    public int health;
    public TMP_Text healthText;
    public Slider healthBar;

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
        if (health <= 0)
        {
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
        Debug.Log("Player died!");
        // add your death logic here, e.g.:
        // SceneManager.LoadScene("GameOver");
        // gameObject.SetActive(false);
    }
}
