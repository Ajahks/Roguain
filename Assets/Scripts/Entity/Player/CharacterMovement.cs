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

    public State state;

    public enum State
    {
        Normal,
        Roll,
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<Player>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //state = State.Normal;
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
        Debug.Log("X: " + x + " Y: " + y);
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
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(x, y, 0);
        if(x == 0 && y == 0)
        {
            if (sr.flipX == true)
                movement = new Vector3(-1, 0, 0);
            else
                movement = new Vector3(1, 0, 0);
        }
        transform.position += movement * playerStats.rollSpeed * Time.deltaTime;
 
                
    }
}
