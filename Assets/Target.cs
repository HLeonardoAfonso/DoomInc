using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathParticles;

    [Header("Drop")]
    public GameObject itemPrefab;
    [Range(0f, 1f)]
    public float dropChance = 1f;
    public Vector3 dropOffset = Vector3.zero;

    [Header("Audio")]
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        AudioSource.PlayClipAtPoint(hurtSound, transform.position, 1f);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        if (deathParticles != null)
            Instantiate(deathParticles, transform.position, Quaternion.identity);
        if (itemPrefab != null)
            Instantiate(itemPrefab, transform.position + dropOffset, Quaternion.identity);
        if (TargetUI.Instance != null)
            TargetUI.Instance.RegisterKill();
        Destroy(gameObject);
    }
}
