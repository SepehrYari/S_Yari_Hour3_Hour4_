using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScriptController : MonoBehaviour
{
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if player is moving with in wasd movement


        //for down animation
        if (Input.GetKey("s"))
        {
            //set the isWalking bool
            animator.SetBool("isWalkingDown", true);
            
        }

        if (!Input.GetKey("s"))
        {
            //stops the walking
            animator.SetBool("isWalkingDown", false);
        }

        //for up animations
        if (Input.GetKey("w"))
        {
            //set the isWalking bool
            animator.SetBool("isWalkingUp", true);
        }

        if (!Input.GetKey("w"))
        {
            //stops the walking
            animator.SetBool("isWalkingUp", false);
        }

        //for left animation
        if (Input.GetKey("a"))
        {
            //set the isWalking bool
            animator.SetBool("isWalkingLeft", true);
        }

        if (!Input.GetKey("a"))
        {
            //stops the walking
            animator.SetBool("isWalkingLeft", false);
        }

        //for right animation
        if (Input.GetKey("d"))
        {
            //set the isWalking bool
            animator.SetBool("isWalkingRight", true);
        }

        if (!Input.GetKey("d"))
        {
            //stops the walking
            animator.SetBool("isWalkingRight", false);
        }
    }
}
