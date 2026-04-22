using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int initialHealth = 100;
    public int health;
    public TMP_Text healthText;
    public Slider healthBar;

    [Header("Damage Flash")]
    public Image damageFlashImage;
    public float flashAlpha = 0.4f;
    public float flashDuration = 0.3f;
    Coroutine flashCoroutine;

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
        TriggerDamageFlash();

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

    void TriggerDamageFlash()
    {
        if (damageFlashImage == null) return;

        // Stop any ongoing flash before starting a new one
        if (flashCoroutine != null) StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        damageFlashImage.color = new Color(1f, 0f, 0f, flashAlpha);

        // Fade out
        float elapsed = 0f;
        while (elapsed < flashDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(flashAlpha, 0f, elapsed / flashDuration);
            damageFlashImage.color = new Color(1f, 0f, 0f, alpha);
            yield return null;
        }

        // Ensure fully transparent at the end
        damageFlashImage.color = new Color(1f, 0f, 0f, 0f);
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = $"HP: {health}/{initialHealth}";

        if (healthBar != null)
            healthBar.value = (float)health / initialHealth;  // Fixed: cast to float
    }

    void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}