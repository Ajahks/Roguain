using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D playerRigidBody;
    Player playerStats;
    Animator anim;
    SpriteRenderer sr;
    public int rollMulti = 10;
    public int rollDistance = 15;
     
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

    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(x, y);
        playerRigidBody.velocity = movement * playerStats.Speed;
        if (x == 0 && y == 0)
        {
            anim.SetBool("IsMoving", false);
            
            return;
        }
        
        if(x < 0)
        {
            sr.flipX = true;
        } else
        {
            sr.flipX = false;
        }
        anim.SetBool("IsMoving",true);
        
    }

    public void Roll()
    {
        //code about invinsibility frame where you cannot take damage
        //add animation
        playerRigidBody.AddForce(new Vector2(2000f,0));

                
    }
}
