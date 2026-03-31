using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 25;
    public AudioClip pickUpSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            health?.Healing(healthAmount);
            Destroy(gameObject);
        }
    }
}