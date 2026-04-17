using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            health?.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
