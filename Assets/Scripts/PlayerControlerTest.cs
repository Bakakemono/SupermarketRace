using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Vector3 ForceTurn;

    [SerializeField]
    public int playerLife = 10;

    private int Cooldown = 0;


    private Rigidbody rigid;

    public float speed;

    private bool rightTurn;
    private bool leftTurn;

    public float horizontalInput;

    private TargetCamera Camera;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Camera = FindObjectOfType<TargetCamera>();
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

            if (horizontalInput != 0 && speed < 20)
            {
                
                    transform.Rotate(ForceTurn * horizontalInput * ((50 - transform.InverseTransformDirection(rigid.velocity).z) / 100));
                
                rigid.AddRelativeForce(acceleration);
            }
            else if (horizontalInput != 0)
            {
                
                    transform.Rotate(ForceTurn * horizontalInput * ((50 - transform.InverseTransformDirection(rigid.velocity).z) / 100));
                
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
        Cooldown = 100;
        for (int i = 0; i < 50; i++)
        {
            transform.Rotate(0, 7.2f, 0);
            yield return new WaitForSeconds(0.01f);
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
        if (other.gameObject.name == "StartTrigger")
        {
            SceneManager.LoadScene("StartScene");
        }
        if (other.gameObject.name == "ExitTrigger")
        {
            Application.Quit();
        }

    }
}
