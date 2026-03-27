using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public float shootingCooldown = 0.5f;
    public float bulletSpeed = 40f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootingCooldown)
        {
            shootPlayer();
            timer = 0f;
        }
    }

    void shootPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;

        Destroy(bullet, 4f);
    }
}
