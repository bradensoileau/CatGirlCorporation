using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign your player's transform here
    public float smoothing = 5f; // Adjust this value to change the smoothness of the camera movement
    Vector3 offset; // The initial offset from the target

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Create a position the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and its target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
