using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform target;             // The target to follow (the player in this case)
    public float smoothTime = 0.3f;     // The smoothness factor for camera movement
    public Vector3 offset;              // The offset between the camera and the target

    private Vector3 velocity;           // Velocity used by SmoothDamp

    void FixedUpdate()
    {
        // Calculate the target position for the camera (only considering "x" and "z" axes)
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z) + offset;

        // Use SmoothDamp to smoothly interpolate between the current camera position and the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}