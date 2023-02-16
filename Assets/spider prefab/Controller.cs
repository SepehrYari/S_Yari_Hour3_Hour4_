using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterController ThecharacterController;

    //for movement
    public float Speed = 8f;

    //for jumping
    public float JumpForce = 3f;


    //for the falling force down (GRAVITY)
    Vector3 velocity;
    public float Gravity = -9.81f;

    //for checking if the character is touching the ground (ground check point needs to be at the bottom of the model/sprite)
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    //all cosmetic code
    public SpriteRenderer TheSR;


    private Vector2 moveInput;





    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //for checking if the character is touching the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        //for movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        ThecharacterController.Move(move * Time.deltaTime * Speed);



        //for the falling force down (GRAVITY)
        velocity.y += Gravity * Time.deltaTime;

        ThecharacterController.Move(velocity * Time.deltaTime);

        //for jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpForce * -2 * Gravity);
        }


        //all cosmetic code

        moveInput.x = Input.GetAxis("Horizontal");

        if (!TheSR.flipX && moveInput.x < 0)
        {
            TheSR.flipX = true;
        }
        else if (TheSR.flipX && moveInput.x > 0)
        {
            TheSR.flipX = false;
        }






    }
}
