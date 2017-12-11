using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField]
    private float PlayerAcceleration;
    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField]
    private float playerMaxSpeed;

    private Rigidbody rigid;
    

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Création d'un nouveau vecteur de déplacement
        Vector3 acceleration = new Vector3();
        Vector3 move = new Vector3();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Récupération des touches haut et bas
            acceleration.z += verticalInput * PlayerAcceleration;

        // Récupération des touches gauche et droite
            move.x += horizontalInput*playerMoveSpeed;

        // On applique le mouvement à l'objet
        if (rigid.velocity.z <= playerMaxSpeed)
        {
            rigid.AddForce(acceleration, ForceMode.Acceleration);
        }
        rigid.AddForce(move, ForceMode.VelocityChange);
    }
}
