using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesPlayer : MonoBehaviour
{
    //Run
    public int runSpeed = 1;
    
    Animator animator;  

    //Run
    float horizontal;
    float vertical;
    bool facingLeft;

    //Fist

    bool isFighting;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontal!=0 ? horizontal : vertical));

    }

    void FixedUpdate()
    {

        if(Input.GetButton("fist") && horizontal == 0 && vertical == 0)
        {
            isFighting = true;
            animator.SetTrigger("fist");

        }else 
        {
            isFighting = false;
        }



        if(isFighting != true)
        {
            Vector3 movement = new Vector3(horizontal * runSpeed, vertical * runSpeed, 0.0f);
            transform.position = transform.position + movement * 7 * Time.deltaTime;
            Flip(horizontal);
        }

    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingLeft || horizontal < 0 && facingLeft)
        {
            facingLeft = !facingLeft;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
    }
}
