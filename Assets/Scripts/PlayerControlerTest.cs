using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerTest : MonoBehaviour
{

    [Header("Move")]
    [SerializeField]
    private float PlayerAccelerationForce = 100;
    [SerializeField]
    private float playerMoveSpeed = 1;
    [SerializeField]
    private float playerMaxSpeed = 30;
    [SerializeField]
    private float playerForceDrag = 10;
    [SerializeField]
    private Vector3 ForceTurn = new Vector3(0, 5, 0);
    [SerializeField]
    private int playerMinSpeedTurn = 50;
    public float speed;
    public  int wheelSpeed = 130;
    private int speedRegularization = 20;
    

    [Header("Life")]
    [SerializeField]
    public int playerLife = 10;

    [Header("CoolDown")]
    [SerializeField]
    private int SetCooldown = 100;
    private int Cooldown = 0;
    

    [Header("Damage")]
    [SerializeField]
    private int nbTurn = 1;
    [SerializeField]
    private float stepTurn = 50;
    private float oneTurn = 360;
    [SerializeField]
    private float takeDammageTime = 0.5f;

    private Rigidbody rigid;

    
    private int perCent = 100;

    public float horizontalInput;

    private CameraManager Camera;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Camera = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown--;
        if (Cooldown <= 0)
        {
            Cooldown = 0;
        }
        speed = transform.InverseTransformDirection(rigid.velocity).z;
        // Création d'un nouveau vecteur de déplacement
        Vector3 acceleration = new Vector3();
        Vector3 move = new Vector3();
        
        horizontalInput = Input.GetAxis("Horizontal");
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
            
            if (horizontalInput != 0 && speed < speedRegularization)
            {
                transform.Rotate(ForceTurn * horizontalInput * ((playerMinSpeedTurn - transform.InverseTransformDirection(rigid.velocity).z) / perCent));
                rigid.AddRelativeForce(acceleration);
            }
            else if (horizontalInput != 0)
            {
                transform.Rotate(ForceTurn * horizontalInput * ((playerMinSpeedTurn - transform.InverseTransformDirection(rigid.velocity).z) / perCent));
            }
            else
            {
                rigid.AddRelativeForce(acceleration);
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Customer")
        {
            if (Cooldown == 0)
            StartCoroutine(TakeDamage());
        }
    }
    private IEnumerator TakeDamage()
    {

        playerLife--; 
        Cooldown = SetCooldown;
        for (int i = 0; i < stepTurn; i++)
        {
            transform.Rotate(0, nbTurn * oneTurn/stepTurn, 0);
            yield return new WaitForSeconds(takeDammageTime/stepTurn);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CameraDown")
        {
            Camera.CameraPostion = 1;
        }
        if (other.gameObject.tag == "CameraRight")
        {
            Camera.CameraPostion = 2;
        }
        if (other.gameObject.tag == "CameraLeft")
        {
            Camera.CameraPostion = 3;
        }
        if (other.gameObject.tag == "CameraUp")
        {
            Camera.CameraPostion = 4;
        }
    }
}
