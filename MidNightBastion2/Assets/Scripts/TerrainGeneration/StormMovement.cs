using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Vector3 movementDirection;
    public float mapBoundaryX = 50f;
    public float mapBoundaryZ = 50f;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;

        if (movementDirection == Vector3.zero)
        {
            movementDirection = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementDirection * movementSpeed * Time.deltaTime;
        if (Mathf.Abs(transform.position.x) > mapBoundaryX||Mathf.Abs(transform.position.z)> mapBoundaryZ)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
