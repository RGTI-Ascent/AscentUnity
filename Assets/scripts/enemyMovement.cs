using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 10f;
    public float maxAngle = 10f;
    private float direction = 1f;
    private float currentAngle;

    private float startAngle;

    void Start() {
        startAngle = transform.eulerAngles.y; // read position from editor once
        currentAngle = startAngle;
    }

    void Update() {
        currentAngle += direction * speed * Time.deltaTime;
        
        if(currentAngle >= startAngle + maxAngle) direction = -1f;
        if(currentAngle <= startAngle - maxAngle) direction = 1f;
        
        transform.eulerAngles = new Vector3(0, currentAngle, 0);
    }
}