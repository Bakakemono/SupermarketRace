using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemysManager : MonoBehaviour {

    private const float minimumValue = 0.01f;
    private Transform nextPosition;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform[] transformGameObject;

    // Use this for initialization
    void Start()
    {
        nextPosition = transformGameObject[Random.Range(0,transformGameObject.Length - 1)];
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
