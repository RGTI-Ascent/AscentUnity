using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour {

    public Rigidbody body;
    public Transform playerTransform;
    public InputAction jump; 
    public InputAction moveLeft;
    public InputAction moveRight;

    public bool grounded;
    public float jumpIntensity;
    public float speed;

    float currentTurnSpeed = 0f;  
    public float turnAccel = 720f; 

    private float coyoteTime = 0.2f;
    private float coyoteTimer;
    private float jumpBuffer = 0.2f;
    private float bufferCounter;

    void OnEnable(){
        jump = new InputAction("Jump", binding: "<Keyboard>/w");
        jump.Enable();
        moveLeft = new InputAction("moveLeft", binding: "<Keyboard>/a");
        moveLeft.Enable();
        moveRight = new InputAction("moveRight", binding: "<Keyboard>/d");
        moveRight.Enable();
    }

    void OnDisable(){
        jump.Disable();
        moveLeft.Disable(); moveRight.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        if(grounded) coyoteTimer = coyoteTime; 
        else coyoteTimer -= Time.deltaTime;

        if(jump.WasPressedThisFrame()) bufferCounter = jumpBuffer;
        else bufferCounter -= Time.deltaTime;

        if(bufferCounter > 0f && coyoteTimer > 0f) {
            body.linearVelocity = new Vector3(body.linearVelocity.x, jumpIntensity, body.linearVelocity.z);
            coyoteTimer = 0f;
            bufferCounter = 0f;
        } 

        if(body.linearVelocity.y < 0.001f && body.linearVelocity.y > -0.001f) grounded = true; 

        float input = 0f;
        if (moveLeft.IsPressed()) input = 1f;
        if (moveRight.IsPressed()) input = -1f;

        float deltaY = input * speed * Time.deltaTime;
        playerTransform.Rotate(Vector3.up, deltaY, Space.Self);
    }

    private void OnCollisionEnter(Collision other) {
        Vector3 normal = other.GetContact(0).normal;
        if(normal == Vector3.up) {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        grounded = false;
    }
}
