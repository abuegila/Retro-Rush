using UnityEngine;

#pragma warning disable 649

namespace UnityStandardAssets.Utility
{
    // Smoothly follows a target with adjustable height and rotation damping.
    public class SmoothFollow : MonoBehaviour
    {
        // The target we are following (e.g., the player or a specific camera target).
        [SerializeField] private Transform target;
        
        // The horizontal distance between the camera and the target.
        [SerializeField] private float distance = 10.0f;

        // The vertical height of the camera above the target.
        [SerializeField] private float height = 5.0f;

        // How smoothly the camera rotation adjusts to the target's rotation.
        [SerializeField] private float rotationDamping;

        // How smoothly the camera adjusts to height changes.
        [SerializeField] private float heightDamping;

        // Initialize the target reference.
        private void Start() 
        {
            // Find the object with the tag "CameraTarget" and assign it as the target.
            target = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        }

        // LateUpdate ensures the camera movement happens after all other updates.
        private void LateUpdate()
        {
            // Exit if the target is not set.
            if (!target) return;

            // Get the target’s desired rotation and height.
            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight = target.position.y + height;

            // Get the camera’s current rotation and height.
            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            // Smoothly interpolate rotation around the Y-axis.
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            // Smoothly interpolate height to follow the target.
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the rotation angle into a quaternion rotation.
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Update the camera position behind the target.
            transform.position = target.position - (currentRotation * Vector3.forward * distance);

            // Adjust the camera height smoothly.
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // Ensure the camera always looks at the target.
            transform.LookAt(target);
        }
    }
}
