using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;  

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gun weapon = other.GetComponentInChildren<Gun>();

            if (weapon != null)
            {
                weapon.bullets += ammoAmount;
                Destroy(gameObject); 
            }
        }
    }
}