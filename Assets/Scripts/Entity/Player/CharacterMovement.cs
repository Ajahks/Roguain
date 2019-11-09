using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D playerRigidBody;
    Player playerStats;
    Animator anim;
    SpriteRenderer sr;
     
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<Player>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Roll();
        }
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(x == 0 && y == 0)
        {
            anim.SetBool("IsMoving", false);
            return;
        }
        Vector2 movement = new Vector2(x,y);
        if(x < 0)
        {
            sr.flipX = true;
        } else
        {
            sr.flipX = false;
        }
        anim.SetBool("IsMoving",true);
        playerRigidBody.velocity = movement * playerStats.Speed;
    }

    private void Roll()
    {
        //code about invinsibility frame where you cannot take damage
        //add animation
    }
}
