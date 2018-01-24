using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsManager : MonoBehaviour {

    HingeJoint hinge;
    JointMotor motor;
    PlayerControlerTest playerControler;

	// Use this for initialization
	void Start () {
        playerControler = FindObjectOfType<PlayerControlerTest>();
        hinge = gameObject.GetComponent<HingeJoint>();
        motor = hinge.motor;
        
    }
	
	// Update is called once per frame
	void Update () {
        motor.force = 130*playerControler.horizontalInput;
        hinge.motor = motor;
        
    }
}
