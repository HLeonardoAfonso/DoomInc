using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float radius = 3f;

    public float attackRate = 15f;
    public int damageAmount = 20;
    private float nextTimeToFire = 0f; 

    private Transform target;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            target = player.transform;
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= radius && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / attackRate;

            PlayerHealth health = target.GetComponent<PlayerHealth>();
            health?.TakeDamage(damageAmount);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
