using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    private bool moveLeft = false;
    private bool moveRight = false;
    // Start is called before the first frame update

    
    // when button is pressed, move camera to the left smoothly
    private void Update()
    {
        MoveCamera();
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
    }
    
    private void MoveCamera()
    {
        if (moveLeft)
        {
            // if camera.x is -2 stop
            if (transform.position.x <= -2)
            {
                StopMoving();
                return;
            }
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (moveRight)
        {
            if (transform.position.x >= 2)
            {
                StopMoving();
                return;
            }
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
    
}
