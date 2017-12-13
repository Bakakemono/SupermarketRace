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

    private Rigidbody rigid;

    public float speed;
    

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rigid.velocity.z;
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
        if (rigid.velocity.z <= playerMaxSpeed && rigid.velocity.z >= 0)
        {
            rigid.AddForce(acceleration, ForceMode.Acceleration);
        }
        rigid.AddForce(move, ForceMode.VelocityChange);
    }
}
