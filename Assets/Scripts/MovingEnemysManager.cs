using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemysManager : MonoBehaviour
{

    private const float minimumValue = 0.01f;
    private Transform nextPosition;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform[] transformGameObject;
    [SerializeField]
    private Transform childTransform;

    // Use this for initialization
    void Start()
    {
        nextPosition = transformGameObject[Random.Range(0, transformGameObject.Length - 1)];

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(nextPosition);
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPosition.position, movementSpeed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nextPosition.position) <= minimumValue)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        nextPosition = transformGameObject[Random.Range(0, transformGameObject.Length - 1)];
    }
}
