using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemysManager : MonoBehaviour {


    private const float minimumValue = 0.01f;
    private Transform nextPosition;

    private SoundManager soundManager;
    private bool itIsTime = false;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform[] transformGameObject;

    private PlayerControlerTest playerControler;

    // Use this for initialization
    void Start()
    {
        nextPosition = transformGameObject[Random.Range(0,transformGameObject.Length - 1)];
        soundManager = FindObjectOfType<SoundManager>();
        playerControler = FindObjectOfType<PlayerControlerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, movementSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPosition.position) <= minimumValue)
        {
            ChangeDestination();
        }
        transform.LookAt(nextPosition);
    }
    private void ChangeDestination()
    {
        nextPosition = transformGameObject[Random.Range(0, transformGameObject.Length)];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !playerControler.isTakingDammage)
        {
            soundManager.PlayCustomerHit();
            StartCoroutine(HitDestroy());
            if(itIsTime)
                Destroy(gameObject);
        }
    }

    private IEnumerator HitDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        itIsTime = true;

    }
}
