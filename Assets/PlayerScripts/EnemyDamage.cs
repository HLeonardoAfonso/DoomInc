using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            health?.TakeDamage(damageAmount);
        }
    }
}
