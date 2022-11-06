using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsManager : MonoBehaviour {

    private HingeJoint hinge;
    private JointMotor motor;
    private PlayerControlerTest playerControler;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        playerControler = FindObjectOfType<PlayerControlerTest>();
        hinge = gameObject.GetComponent<HingeJoint>();
        motor = hinge.motor;
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //motor.force = playerControler.wheelSpeed * playerControler.horizontalInput;
        //hinge.motor = motor;
        rigidbody.AddForce(transform.forward * (float)playerControler.wheelSpeed * playerControler.horizontalInput);
    }
}
