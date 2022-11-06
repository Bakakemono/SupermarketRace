using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [Header("PostionCamera")]
    [SerializeField]
	private Transform Player;
    [SerializeField]
    private Transform PostionCamera;
    public int CameraPostion = 1;
    private int heightCamera = 3;
    private int distanceCamera = 7;
    float step = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float step = 30 * Time.deltaTime;
        


        if (CameraPostion == 1)
        {
            PostionCamera.position = new Vector3(Player.position.x, Player.position.y + heightCamera, Player.position.z - distanceCamera);
        }
        if (CameraPostion == 2)
        {
            PostionCamera.position = new Vector3(Player.position.x + distanceCamera, Player.position.y + heightCamera, Player.position.z);
        }
        if (CameraPostion == 3)
        {
            PostionCamera.position = new Vector3(Player.position.x - distanceCamera, Player.position.y + heightCamera, Player.position.z);
        }
        if (CameraPostion == 4)
        {
            PostionCamera.position = new Vector3(Player.position.x, Player.position.y + heightCamera, Player.position.z + distanceCamera);
        }

        transform.position = Vector3.MoveTowards(transform.position, PostionCamera.position, step);
        transform.LookAt(Player);
        
    }

    
}
