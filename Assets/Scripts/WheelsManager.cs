using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsManager : MonoBehaviour {

    HingeJoint hingeJoint;
    JointMotor motor;

	// Use this for initialization
	void Start () {
        hingeJoint = GetComponent<HingeJoint>();
        motor = hingeJoint.motor;
        motor.force = 50;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
