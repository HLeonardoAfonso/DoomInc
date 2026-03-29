using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public Transform firePoint;
    public float shootingCooldown = 0.5f;
    public float bulletSpeed = 30f;
    public float lookRadius = 35f;

    private float timer;

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            timer += Time.deltaTime;
            if (timer >= shootingCooldown)
            {
                shootPlayer();
                timer = 0f;
            }
        }
        else
        {
            timer = 0f; // reset timer when out of range so it doesn't shoot instantly on re-entry
        }
    }

    void shootPlayer()
    {
        Transform spawnPoint = firePoint != null ? firePoint : transform;
        
        Vector3 direction = (player.position - spawnPoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;

        // Ignore collision between bullet and ALL colliders on this enemy
        Collider bulletCollider = bullet.GetComponent<Collider>();
        Collider[] enemyColliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in enemyColliders)
        {
            Physics.IgnoreCollision(bulletCollider, col);
        }

        Destroy(bullet, 4f);
    }
}
