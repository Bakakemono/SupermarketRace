using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    float speedInput = 0.0f;
    readonly float speedMultiplicator = 20.0f;
    float horizontalInput = 0.0f;
    float maxTurnDegreePerFrame = 5.0f;
    float maxSpeed = 10.0f;

    // Limit lifted when boosting.
    float boostedMax = 100.0f;

    float horizontalMovement = 0.0f;

    [SerializeField] Transform cameraTransform;

    [SerializeField] float currentSpeed = 0.0f;
    Vector3 velocity = Vector3.zero;
    Vector3 moveDirection = Vector3.forward;

    [SerializeField] Transform modelTransform;

    float timeForMaxSpeed = 3.0f;
    float frameForMaxSpeed = 0.0f;
    float currentFrameCount = 0.0f;

    bool isAccelerating = false;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        cameraTransform = FindObjectOfType<Camera>().transform;
        frameForMaxSpeed = Mathf.Round(timeForMaxSpeed / Time.fixedDeltaTime);
        timeForMaxSpeed = timeForMaxSpeed * Time.fixedDeltaTime;
        moveDirection = transform.forward;
    }

    private void FixedUpdate() {
        //rigidbody.AddForce(transform.forward * speedInput * speedMultiplicator);

        rigidbody.velocity = 
            Vector3.Lerp(
                Vector3.zero,
                transform.forward * speedInput * speedMultiplicator,
                currentFrameCount / frameForMaxSpeed
                );

        if(speedInput != 0.0f) {
            currentFrameCount++;
            if(currentFrameCount > frameForMaxSpeed) {
                currentFrameCount = frameForMaxSpeed;
            }
        }
        else {
            currentFrameCount--;
            if(currentFrameCount <= 0) {
                currentFrameCount = 0;
            }
        }



        float angleForwardVelocity = 
            Mathf.Abs(
                Mathf.Rad2Deg * Mathf.Acos(
                    Vector3.Dot(velocity.normalized, transform.forward)
                    )
                );

        transform.Rotate(
            new Vector3(
                0.0f,
                horizontalInput * currentSpeed / maxTurnDegreePerFrame * (angleForwardVelocity > 90.0f? -1.0f : 1.0f),
                0.0f
                )
            );

        //rigidbody.velocity = new Vector3(transform.forward.z, transform.forward.y, -transform.forward.x) * horizontalMovement;

        cameraTransform.position = transform.position + moveDirection * -5.0f + transform.up * 3.0f;
        cameraTransform.LookAt(cameraTransform.position + (transform.forward/* * 3.0f + velocity.normalized*/).normalized / 2.0f);
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        speedInput = Input.GetAxis("Accelerating");

        if(speedInput != 0 && !isAccelerating) {
            isAccelerating = true;
            
        }

        velocity = rigidbody.velocity;
        currentSpeed = velocity.magnitude;
        Debug.Log(speedInput);
        if(velocity != Vector3.zero) {
            moveDirection = velocity.normalized;
        }

        if(currentSpeed >= maxSpeed) {
            Vector3 currentDirection = velocity.normalized;
            rigidbody.velocity = currentDirection * maxSpeed;
        }

        if(Input.GetKey("e")) {
            horizontalMovement = 1.0f;
        }
        if(Input.GetKey("q")) {
            horizontalMovement = -1.0f;
        }
    }

    // DEBUG //

    void OnGUI() {
        Event e = Event.current;
        if(e.isKey) {
            Debug.Log("Detected key code: " + e.keyCode);
        }
    }
}
