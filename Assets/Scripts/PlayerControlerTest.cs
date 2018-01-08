using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerTest : MonoBehaviour
{

    [Header("Move")]
    [SerializeField]
    private float PlayerAccelerationForce;
    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField]
    private float playerMaxSpeed;
    [SerializeField]
    private float playerForceDrag;
    [SerializeField]
    private Vector3 ForceTurnRight;
    [SerializeField]
    private Vector3 ForceTurnLeft;



    private Rigidbody rigid;

    public float speed;

    private bool rightTurn;
    private bool leftTurn;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = transform.InverseTransformDirection(rigid.velocity).z;
        // Création d'un nouveau vecteur de déplacement
        Vector3 acceleration = new Vector3();
        Vector3 move = new Vector3();
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Récupération des touches haut et bas
        if (verticalInput >= 0)
            acceleration.z += verticalInput * PlayerAccelerationForce;

        if (verticalInput < 0)
            acceleration.z += verticalInput * playerForceDrag;

        // Récupération des touches gauche et droite
        move.y += horizontalInput * playerMoveSpeed;
        

        if (transform.InverseTransformDirection(rigid.velocity).z <= playerMaxSpeed /*&& transform.InverseTransformDirection(rigid.velocity).z >= 0*/)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Time.deltaTime * 1.0f);
            //transform.Rotate(ForceTurnRight * transform.InverseTransformDirection(rigid.velocity).z);
            //rigid.velocity = transform.forward;
            
            rigid.AddRelativeForce(acceleration, ForceMode.Acceleration);
            transform.Rotate(ForceTurnLeft * horizontalInput);
            //rigid.AddRelativeForce(move, ForceMode.VelocityChange);


        }
    }

}
