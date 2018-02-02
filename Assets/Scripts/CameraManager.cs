using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public Transform Player;
    public Transform PostionCamera;
    public int CameraPostion = 1;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = 40 * Time.deltaTime;
        if (CameraPostion == 1)
        {
            PostionCamera.position = new Vector3(Player.position.x, Player.position.y + 3, Player.position.z - 7);
            transform.position = Vector3.MoveTowards(transform.position, PostionCamera.position, step);
        }
        if (CameraPostion == 2)
        {
            PostionCamera.position = new Vector3(Player.position.x + 7, Player.position.y + 3, Player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, PostionCamera.position, step);
        }
        if (CameraPostion == 3)
        {
            PostionCamera.position = new Vector3(Player.position.x - 7, Player.position.y + 3, Player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, PostionCamera.position, step);
        }
        if (CameraPostion == 4)
        {
            PostionCamera.position = new Vector3(Player.position.x, Player.position.y + 3, Player.position.z + 7);
            transform.position = Vector3.MoveTowards(transform.position, PostionCamera.position, step);
        }
        transform.LookAt(Player);
    }
}
