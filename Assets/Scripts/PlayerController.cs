using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField]
    private float PlayerAccelerationForce;
    [SerializeField]
    private float playerLateralMoveSpeed;
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
        if(verticalInput >= 0)
            acceleration.z += verticalInput * PlayerAccelerationForce;

        if (verticalInput < 0)
            acceleration.z += verticalInput * playerForceDrag;

        // Récupération des touches gauche et droite
        move.x += horizontalInput*playerLateralMoveSpeed;

        

        // On applique le mouvement à l'objet
        if (transform.InverseTransformDirection(rigid.velocity).z <= playerMaxSpeed && transform.InverseTransformDirection(rigid.velocity).z >= 0)
        {
          
            if (transform.InverseTransformDirection(rigid.velocity).z > 0 && leftTurn)
            {
                transform.Rotate(ForceTurnLeft * transform.InverseTransformDirection(rigid.velocity).z);
                rigid.velocity = transform.forward * speed;
                rigid.AddRelativeForce(acceleration, ForceMode.Acceleration);
                rigid.AddRelativeForce(move, ForceMode.VelocityChange);

            }
            else if (transform.InverseTransformDirection(rigid.velocity).z > 0 && rightTurn)
            {
                transform.Rotate(ForceTurnRight * transform.InverseTransformDirection(rigid.velocity).z);
                rigid.velocity = transform.forward;
                rigid.AddRelativeForce(acceleration, ForceMode.Acceleration);
                rigid.AddRelativeForce(move, ForceMode.VelocityChange);

            }
            else
            {
                rigid.AddRelativeForce(acceleration, ForceMode.Acceleration);
                rigid.AddRelativeForce(move,  ForceMode.VelocityChange);
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BeginRightTurn")
        {
            
            rightTurn = true;
        }

        if (other.tag == "BeginLeftTurn")
        {
            leftTurn = true;
        }

        if (other.tag == "EndRightTurn")
        {
            
            rightTurn = false;
        }

        if (other.tag == "EndLeftTurn")
        {
            leftTurn = false;
        }
    }
}
