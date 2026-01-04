using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public Transform player;         
    public float towerRadius = 5f;   
    public float heightOffset = 2f;  
    public float distanceOffset = 8f; 
    public float smoothing = 3f;     

    private Vector3 targetPosition;

    void LateUpdate()
    {
        float angle = Mathf.Atan2(player.position.z, player.position.x); 

        float camX = Mathf.Cos(angle) * (towerRadius + distanceOffset);
        float camZ = Mathf.Sin(angle) * (towerRadius + distanceOffset);
        float camY = heightOffset + player.position.y; 

        targetPosition = new Vector3(camX, camY, camZ);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        Quaternion targetRot = Quaternion.LookRotation(player.position + Vector3.up * 0.3f - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, smoothing * Time.deltaTime);
    }
}
