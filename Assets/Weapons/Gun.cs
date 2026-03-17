using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float bullets = 10f;

    public float fireRate = 15f;
    public float impactForce = 30f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    
    InputAction shootAction;

    public AudioClip emptyMagazineSound;
    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        // Left mouse button binding
        shootAction = new InputAction("Shoot", binding: "<Mouse>/leftButton");
    }

    void OnEnable()
    {
        shootAction.Enable();
    }

    void OnDisable()
    {
        shootAction.Disable();
    }

    void Update()
    {
        if (shootAction.IsPressed() && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (bullets <= 0)
            {
                audioSource.PlayOneShot(emptyMagazineSound);
            } else {
                Shoot();
                bullets--;
                audioSource.PlayOneShot(shootSound);
            }
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {                
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}