using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Gun Stats")]
    public float damage = 10f;
    public float range = 100f;
    public int bullets = 30;
    public float fireRate = 12f;
    public float impactForce = 30f;

    float nextTimeToFire = 0f;

    [Header("References")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;
    public MouseLook mouseLook;

    [Header("Recoil")]
    public float recoilUpPerShot = 1.8f;

    InputAction shootAction;
    AudioSource audioSource;

    public AudioClip emptyMagazineSound;
    public AudioClip shootSound;

    void Awake()
    {
        shootAction = new InputAction("Shoot", binding: "<Mouse>/leftButton");
    }

    void OnEnable() => shootAction.Enable();
    void OnDisable() => shootAction.Disable();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (shootAction.IsPressed() && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            if (bullets <= 0)
            {
                audioSource.PlayOneShot(emptyMagazineSound);
                return;
            }

            Shoot();
        }
    }

    void Shoot()
    {
        bullets--;
        muzzleFlash.Play();
        audioSource.PlayOneShot(shootSound);

        // 🔥 vertical recoil only
        mouseLook.AddRecoil(recoilUpPerShot);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
                target.TakeDamage(damage);

            if (hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * impactForce);

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    }