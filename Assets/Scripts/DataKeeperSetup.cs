using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeperSetup : MonoBehaviour {

    [SerializeField]
    private GameObject DataKeeper;

    private DataKeeperManager dataKeeperManager;

    private void Awake()
    {
        dataKeeperManager = FindObjectOfType<DataKeeperManager>();
        if (dataKeeperManager == null)
        {
            Instantiate(DataKeeper, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
