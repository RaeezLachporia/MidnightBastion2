using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] trackPoints;
    public float moveSpeed = 5f;

    private int currentPointIndex = 0;

    // Update is called once per frame
     void Update()
    {
        if (trackPoints.Length==0)
        {
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveForward();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveBackward();
        }
    }

    private void moveForward()
    {
        if (currentPointIndex < trackPoints.Length-1)
        {
            Transform targetPoint = trackPoints[currentPointIndex + 1];
            moveTowards(targetPoint);

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f) ;
            {
                currentPointIndex++ ;
            }
        }
    }

    private void MoveBackward()
    {
        if (currentPointIndex > 0)
        {
            Transform targetPoint = trackPoints[currentPointIndex - 1];
            moveTowards(targetPoint);

            if (Vector3.Distance(transform.position, targetPoint.position) <0.1f)
            {
                currentPointIndex--;
            }
        }
    }

    private void moveTowards(Transform targetPoint)
    {
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(targetPoint);
    }
}
