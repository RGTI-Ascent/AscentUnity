using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 10f;
    public float maxAngle = 10f;

    float direction = 1f;
    float currentAngle;
    float startAngle;

    Transform sprite;

    void Start() {
        startAngle = transform.eulerAngles.y;
        currentAngle = startAngle;

        sprite = transform.GetChild(0); // sprite child
    }

    void Update() {
        currentAngle += direction * speed * Time.deltaTime;

        if (currentAngle >= startAngle + maxAngle) {
            currentAngle = startAngle + maxAngle; // prevent overshoot
            direction = -1f;
            Flip();
        }
        else if (currentAngle <= startAngle - maxAngle) {
            currentAngle = startAngle - maxAngle; // prevent overshoot
            direction = 1f;
            Flip();
        }

    transform.eulerAngles = new Vector3(0, currentAngle, 0);
}

    void Flip() {
        Vector3 s = sprite.localScale;
        s.x *= -1f;
        sprite.localScale = s;
    }
}