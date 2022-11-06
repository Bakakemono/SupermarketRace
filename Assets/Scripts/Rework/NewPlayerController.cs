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
    
    

    [SerializeField] float currentSpeed = 0.0f;
    Vector3 velocity = Vector3.zero;

    [SerializeField] Transform modelTransform;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        rigidbody.AddForce(transform.forward * speedInput * speedMultiplicator);

        float angleVelocity = 
            Mathf.Abs(
                Mathf.Rad2Deg * Mathf.Acos(
                    Vector3.Dot(velocity.normalized, transform.forward)
                    )
                );

        transform.Rotate(
            new Vector3(
                0.0f,
                horizontalInput * currentSpeed / maxTurnDegreePerFrame * (angleVelocity > 90.0f? -1.0f : 1.0f),
                0.0f
                )
            );
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        speedInput = Input.GetAxis("Vertical");

        velocity = rigidbody.velocity;
        currentSpeed = velocity.magnitude;

        if(currentSpeed >= maxSpeed) {
            Vector3 currentDirection = velocity.normalized;
            rigidbody.velocity = currentDirection * maxSpeed;
        }
    }
}
