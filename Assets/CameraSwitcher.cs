using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera stationaryCamera;
    public Key switchKey = Key.C; // The key to toggle cameras

    private bool usingFirstPerson = true;

    void Start()
    {
        // Ensure only the first-person camera is active at start
        firstPersonCamera.gameObject.SetActive(true);
        stationaryCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current[switchKey].wasPressedThisFrame)
        {
            usingFirstPerson = !usingFirstPerson;

            firstPersonCamera.gameObject.SetActive(usingFirstPerson);
            stationaryCamera.gameObject.SetActive(!usingFirstPerson);
        }
    }
}
