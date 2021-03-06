﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsManager : MonoBehaviour {

    private HingeJoint hinge;
    private JointMotor motor;
    private PlayerControlerTest playerControler;
    


	// Use this for initialization
	void Start () {
        playerControler = FindObjectOfType<PlayerControlerTest>();
        hinge = gameObject.GetComponent<HingeJoint>();
        motor = hinge.motor;
        
    }
	
	// Update is called once per frame
	void Update () {
        motor.force = playerControler.wheelSpeed * playerControler.horizontalInput;
        hinge.motor = motor;
        
    }
}
