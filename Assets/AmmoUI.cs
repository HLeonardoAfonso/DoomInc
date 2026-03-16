using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    public TMP_Text amoText;
    public GameObject currentGun;

    void Update()
    {
        Gun gun = currentGun.GetComponent<Gun>();
        amoText.text = $"Ammo: {gun.bullets}";
    }
}