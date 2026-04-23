using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 10;

    void OnCollisionEnter(Collision collision)
    {
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
        Destroy(gameObject);
    }
}
