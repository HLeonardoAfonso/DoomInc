using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 700f;
    public Transform playerBody;
    public Transform toolPivot;
    float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // off screen prevention
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        
        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // prevent owl head

        // Camera up/down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Player body left/right
        playerBody.Rotate(Vector3.up * mouseX);

        // Tool follow vertical mouse movement
        //toolPivot.localRotation = Quaternion.Euler(-xRotation, 0f, 0f);
    }
}
