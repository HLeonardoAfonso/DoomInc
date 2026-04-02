using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathParticles;

    public AudioClip hurtSound;
    public AudioClip deathSound;
    private AudioSource audioSource;

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
        Destroy(gameObject);
    }
}
