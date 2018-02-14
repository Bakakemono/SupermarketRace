using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeperManager : MonoBehaviour {

    public bool timerMode = true;
    public bool lifesMode = false;
    

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseMode()
    {
        bool tmpSwitch = false;
        if(timerMode && !tmpSwitch)
        {
            timerMode = false;
            lifesMode = true;
            tmpSwitch = true;
        }

        if(lifesMode && !tmpSwitch)
        {
            timerMode = true;
            lifesMode = false;
            tmpSwitch = true;
        }
    }

}
