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
    

    // Use this for initialization
    void Start()
    {
        StartCoroutine(TimeCheck());
    }

    // Update is called once per frame
    void Update()
    {
        //float step = 30 * Time.deltaTime;

        //step = 0.01f /** Time.deltaTime*/;


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

        //if (Vector3.Distance(transform.position, PostionCamera.position) >= 10)
        //{
        //    step *= 2;
        //}
        
        //if (Vector3.Distance(transform.position, PostionCamera.position) >= 1)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, PostionCamera.position, step);
        //}

        //Vector3 position = this.transform.position;
        //position.x = Mathf.Lerp(this.transform.position.x, PostionCamera.position.x, step);
        //position.y = Mathf.Lerp(this.transform.position.y, PostionCamera.position.y, step);
        //position.z = Mathf.Lerp(this.transform.position.z, PostionCamera.position.z, step);

        //this.transform.position = position;

        transform.LookAt(Player);
    }

    private IEnumerator TimeCheck()
    {
        while(true)
        {
            if (Vector3.Distance(transform.position, PostionCamera.position) >= 1)
            {
                Vector3 position = this.transform.position;
                position.x = Mathf.Lerp(this.transform.position.x, PostionCamera.position.x, step);
                position.y = Mathf.Lerp(this.transform.position.y, PostionCamera.position.y, step);
                position.z = Mathf.Lerp(this.transform.position.z, PostionCamera.position.z, step);

                this.transform.position = position;
            }

            yield return new WaitForSeconds(0.01f);

        }
    }
}
