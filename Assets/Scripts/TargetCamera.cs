using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{

    public Transform Target;
    public Transform Target2;
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
            Target2.position = new Vector3(Target.position.x, Target.position.y + 3, Target.position.z - 7);
            transform.position = Vector3.MoveTowards(transform.position, Target2.position, step);
        }
        if (CameraPostion == 2)
        {
            Target2.position = new Vector3(Target.position.x + 7, Target.position.y + 3, Target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target2.position, step);
        }
        if (CameraPostion == 3)
        {
            Target2.position = new Vector3(Target.position.x - 7, Target.position.y + 3, Target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target2.position, step);
        }
        if (CameraPostion == 4)
        {
            Target2.position = new Vector3(Target.position.x, Target.position.y + 3, Target.position.z + 7);
            transform.position = Vector3.MoveTowards(transform.position, Target2.position, step);
        }
        transform.LookAt(Target);
    }
}
