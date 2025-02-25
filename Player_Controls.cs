using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{



    Rigidbody2D body;
    public float horizontal;
    public float vertical;
    //float moveLimiter = 0.7f;
    Direction currentDir;
    public Animator anim;

    Vector2 input;
    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        



        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            vertical = 0;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Debug.Log(body.velocity);
        
        //Debug.Log("Horixontal =" + horizontal);
        //Debug.Log("Vertical =" + vertical);

        if (input != Vector2.zero)
        {

            if (horizontal < 0)
            {
                currentDir = Direction.West;
            }
            if (horizontal > 0)
            {
                currentDir = Direction.East;
            }
            if (vertical < 0)
            {
                currentDir = Direction.South;
            }
            if (vertical > 0)
            {
                currentDir = Direction.North;

            }

        }
        if (currentDir == Direction.North)
        {
            if (vertical != 0)
            {
                anim.Play("Move_Up");

            }
            else
            {
                anim.Play("Idle_Up");

            }
        }
        if (currentDir == Direction.East)
        {
            if (horizontal != 0)
            {
                anim.Play("Move_Right");

            }
            else
            {
                anim.Play("Idle_Right");

            }

        }
        if (currentDir == Direction.South)
        {
            if (vertical != 0)
            {
                anim.Play("Move_Down");

            }
            else
            {
                anim.Play("Idle_Down");

            }


        }
        if (currentDir == Direction.West)
        {
            if (horizontal != 0)
            {
                anim.Play("Move_Left");

            }
            else
            {
                anim.Play("Idle_Left");

            }


        }


    }

    //void FixedUpdate()
    //{
        //if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        //{
            // limit movement speed diagonally, so you move at 70% speed
            //vertical = 0;
        //}

        //body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
   // }

    enum Direction
    {
        North,
        East,
        South,
        West
    }


}
