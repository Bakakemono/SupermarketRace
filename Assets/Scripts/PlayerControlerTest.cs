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
    [SerializeField]
    private PhysicMaterial backWheels;
    [SerializeField]
    private GameObject Smoke;
    private float DriftFriction = 0.1f;
    private float NormalFriction = 1.0f;
    

    [Header("Life")]
    [SerializeField]
    public int playerLife = 10;
    

    [Header("Damage")]
    [SerializeField]
    private int nbTurn = 1;
    [SerializeField]
    private float stepTurn = 50;
    private float oneTurn = 360;
    [SerializeField]
    private float takeDammageTime = 0.5f;
    private MeshRenderer playerMeshRenderer;
    private const float blinkingTime = 0.1f;
    public bool isTakingDammage = false;
    private const float blinkigTimePhase = 0.1f;

    private Rigidbody rigid;

    
    private int perCent = 100;

    public float horizontalInput;

    private CameraManager Camera;
    private GameManager gameManager;
    private TutorialManager tutorialManager;
    private SoundManager soundManager;



    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Camera = FindObjectOfType<CameraManager>();
        playerMeshRenderer = GetComponent<MeshRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        tutorialManager = FindObjectOfType<TutorialManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = transform.InverseTransformDirection(rigid.velocity).z;
        // Création d'un nouveau vecteur de déplacement
        Vector3 acceleration = new Vector3();
        Vector3 move = new Vector3();
        
        horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("SpeedControle");

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

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                backWheels.staticFriction = DriftFriction;
                backWheels.dynamicFriction = DriftFriction;
                Smoke.SetActive(true);

            }
            else if (Input.GetKeyUp(KeyCode.Space) == true)
            {
                backWheels.staticFriction = NormalFriction;
                backWheels.dynamicFriction = NormalFriction;
                Smoke.SetActive(false);
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (!isTakingDammage)
            {
                StartCoroutine(TakeDamage());
                StartCoroutine(IndicateImmortal());
                soundManager.PlayGrandmaHitWall();
            }
        }
    }
    private IEnumerator PlaySoundCustomers()
    {
        yield return new WaitForSeconds(0.4f);
        soundManager.PlayGrandmaHitCustomers();
    }

    private IEnumerator TakeDamage()
    {
        isTakingDammage = true;
        playerLife--;
        for (int i = 0; i < stepTurn; i++)
        {
            transform.Rotate(0, nbTurn * oneTurn/stepTurn, 0);
            yield return new WaitForSeconds(takeDammageTime/stepTurn);
        }
        yield return new WaitForSeconds(0.6f);
        isTakingDammage = false;
    }

    private IEnumerator IndicateImmortal()
    {
        while (isTakingDammage)
        {
            playerMeshRenderer.enabled = false;
            yield return new WaitForSeconds(blinkigTimePhase);
            playerMeshRenderer.enabled = true;
            yield return new WaitForSeconds(blinkigTimePhase);
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
        if (other.gameObject.tag == "WinLine")
        {
            gameManager.Win();
        }
        if (tutorialManager != null)
        {
            if (other.tag == "CanvasTutoOff_1")
            {
                tutorialManager.PanelTuto1();
            }
            if (other.tag == "CanvasTutoOn_2")
            {
                tutorialManager.PanelTuto2On();
            }
            if (other.tag == "CanvasTutoOff_2")
            {
                tutorialManager.PanelTuto2Off();
            }
            if (other.tag == "CanvasTutoOn_3")
            {
                tutorialManager.PanelTuto3On();
            }
            if (other.tag == "CanvasTutoOff_3")
            {
                tutorialManager.PanelTuto3Off();
            }
        }
        if (other.gameObject.tag == "Customer")
        {
            if (!isTakingDammage)
            {
                StartCoroutine(TakeDamage());
                StartCoroutine(IndicateImmortal());
                StartCoroutine(PlaySoundCustomers());
            }
        }
    }   
}
