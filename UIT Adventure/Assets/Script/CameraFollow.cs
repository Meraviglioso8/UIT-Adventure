using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (objectToFollow == null)
        {
            Debug.LogWarning("No object to follow assigned to CameraFollow script.");
            return;
        }

        // Set the camera position to match the character's position plus the offset
        transform.position = objectToFollow.position + offset;
    }
}