using Chracter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    private bool moveLeft = false;
    private bool moveRight = false;
    [SerializeField] BaseCharacter baseCharacter;
    // Start is called before the first frame update

    
    // when button is pressed, move camera to the left smoothly
    private void Update()
    {
        if (moveLeft || moveRight)
        {
            MoveCamera();
        }
        else
        {
            FollowCharacter();
        }
       
    }

    public void MoveLeft()
    {
        Debug.Log("asdf");
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
            if (transform.position.x <= -10)
            {
                StopMoving();
                return;
            }
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (moveRight)
        {
            if (transform.position.x >= 10)
            {
                StopMoving();
                return;
            }
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
    private void FollowCharacter()
    {
        if(baseCharacter.transform.position.x<=-5)
        {
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(baseCharacter.transform.position.x, transform.position.y, transform.position.z);
        }

        
    }


}
