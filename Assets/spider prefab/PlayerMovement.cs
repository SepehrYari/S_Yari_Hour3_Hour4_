using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <Summery>
/// right of the Bat this is a code that makes the player move!!!
/// there are 3 things you will need on your player before you can just slip this code in
/// step 1:     the Ridgid Body componet on the player and then connected to the script
/// 
/// step 2:     You will need to set the floor of the game to a certain layer on unity so that we know what we are jumping off of i.e. Layer: Ground
/// 
/// step 3:     You will need a Ground point empty object on your player model so that the RayCast knows where to emit the inisible line from
///             i.e. the Ground Point needs to be an empty object at  the center of your player model just make sure that the Height of the player is 
///             perfectly assigned to the in game model that is displayed
///             
///






public class PlayerMovement : MonoBehaviour
{
    //this is our variable that lets us use the RigidBody componet from the Player object in unity
    public Rigidbody theRigidBody;

    //these are our public Variables that we can change in unity
    public float MoveSpeed;
    public float JumpForce;
    public float PlayerHeight;

    //this is a special Public variable that lets us know what layer on unity we set for our ground check
    public LayerMask WhatIsGround;

    //this is the variable that will check if the Player is touching the ground in game
    public Transform GroundPoint;

    private bool IsGrounded;

    //these are private Variables
    private Vector2 moveInput; //this variable is what sets up the movement input so we can shorten the Input.GetAxis code



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //these variable are to obtain the unity input for Horizontal and Vertical movement
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");


        //this line of code just makes sure to Normalize the movement of the player so it doesn't speed off
        moveInput.Normalize();


        //this line of code is what sets the movement in action when we obtain our NEW vector 3 variable
        theRigidBody.velocity = new Vector3(moveInput.x * MoveSpeed, theRigidBody.velocity.y, moveInput.y * MoveSpeed);


        RaycastHit hit;
        //this if statement is sending an invisible line down from the groundpoint (which should be at the player's center)
        //when the invisble line is touching the ground it allows the player to jump
        //but if it can't reach the ground then it will assume that the player is not on the ground
        if (Physics.Raycast(GroundPoint.position, Vector3.down, out hit, PlayerHeight * 0.5f + 0.2f, WhatIsGround))
        {
            IsGrounded = true;
            Debug.Log("I am touching the ground");
        }
        else
        {
            IsGrounded = false;
            Debug.Log("I am NOT touching the ground AT ALL");
        }

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            theRigidBody.velocity += new Vector3(0f, JumpForce, 0f);
        }




    }
}
