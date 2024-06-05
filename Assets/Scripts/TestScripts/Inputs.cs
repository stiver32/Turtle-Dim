using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    Inputs myInput;
  
    
    public SpriteRenderer mySprite;
    public Animator myAnimator;

 
    public bool isMoving = false;


    public float moveSpeed = 5f;
    public float rotateSpeed = 700f;

    public void Move()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Check if the player is moving
        bool isCurrentlyMoving = (moveHorizontal != 0f || moveVertical != 0f);
        flipSprite(moveHorizontal);

        if (isCurrentlyMoving != isMoving)
        {
            isMoving = isCurrentlyMoving;
            // Set the animation state
            myAnimator.SetBool("isMoving", isMoving);
            Debug.Log("set true");
        }

        // Move
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void flipSprite(float horizontalInput)
    {
        if (mySprite != null)
        {
            // Check the sign of horizontalInput
            bool flipSprite = horizontalInput < 0f;

            // Flip the sprite horizontally accordingly
            mySprite.flipX = flipSprite;
        }

    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("Throw Projectile");

            if (myAnimator != null)
            {
                myAnimator.SetTrigger("throwPressed");
            }
        }


    }




}
