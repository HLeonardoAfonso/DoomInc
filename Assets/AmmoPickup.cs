using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;  
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
            Gun weapon = other.GetComponentInChildren<Gun>();

            if (weapon != null)
            {
                weapon.bullets += ammoAmount;
                Destroy(gameObject); 
            }
        }
    }
}