using UnityEngine;

public class FaceCamera : MonoBehaviour {
    private Camera mainCamera;

    void Start() {
        mainCamera = Camera.main;
    }

    void Update() {
        Vector3 directionToCamera = mainCamera.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(directionToCamera.x, directionToCamera.z) * Mathf.Rad2Deg;
        
        // Adjust based on parent's current rotation
        float parentAngle = transform.parent.eulerAngles.y;
        float adjustedAngle = angle - parentAngle;
        
        transform.localEulerAngles = new Vector3(90, adjustedAngle, 0);
    }
}