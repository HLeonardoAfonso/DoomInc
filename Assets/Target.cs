using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathParticles;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathParticles != null)
            Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
