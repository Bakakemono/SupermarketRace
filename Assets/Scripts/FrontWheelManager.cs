using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheelManager : MonoBehaviour {


    PlayerControlerTest playerControler;
    private float noInput;

	// Use this for initialization
	void Start () {
        playerControler = FindObjectOfType<PlayerControlerTest>();
	}
	
	// Update is called once per frame
	void Update () {
        
		if (playerControler.horizontalInput < 0)
        {
            transform.Rotate(0, 20, 0);
        }
        else if (playerControler.horizontalInput > 0)
        {
            transform.Rotate(0, -20, 0);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
	}
}
