using UnityEngine;

public class ItemMotion : MonoBehaviour
{
    public float floatHeight = 0.5f;   
    public float floatSpeed = 2f;      
    public float rotationSpeed = 90f;  

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        // Floating
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Rotation
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
