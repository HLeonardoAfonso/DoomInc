using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse")]
    public float mouseSensitivity = 700f;
    public Transform playerBody;

    float xRotation = 0f;

    [Header("Recoil")]
    public float recoilReturnSpeed = 6f;
    public float recoilSnappiness = 10f;

    float recoilX;          
    float recoilXVelocity;  
    float targetRecoilX;    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Look();
        HandleRecoil();
    }

    void Look()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        // Normal look rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply recoil offset (vertical only)
        float finalX = xRotation - recoilX;

        transform.localRotation = Quaternion.Euler(finalX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void HandleRecoil()
    {
        // recoil slowly returns to 0 when not shooting
        targetRecoilX = Mathf.Lerp(targetRecoilX, 0f, recoilReturnSpeed * Time.deltaTime);
        recoilX = Mathf.SmoothDamp(recoilX, targetRecoilX, ref recoilXVelocity, 1f / recoilSnappiness);
    }

    // called by gun every shot
    public void AddRecoil(float recoilUp)
    {
        targetRecoilX += recoilUp;
    }
}