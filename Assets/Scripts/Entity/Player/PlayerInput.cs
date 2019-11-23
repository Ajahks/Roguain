using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerAttack pa;
    CharacterMovement cm;
    bool roll, atk1;
    //float atkTimer = 0;
    //float atkInterval = .5f;
    float rollTimer = 0;
    float rollInterval = 2f; //change to 5+ in real game
    // Start is called before the first frame update
    void Start()
    {
        pa = GetComponentInChildren<PlayerAttack>();
        //pa.gameObject.SetActive(false);
        cm = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rollTimer > 0)
        {
            rollTimer -= Time.deltaTime;
            roll = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                roll = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            roll = false;
        }
        //if (atkTimer > 0)
        //{
        //    atkTimer -= Time.deltaTime;
        //    atk = false;
        //}
        //else
        //{
            if (Input.GetKeyDown(KeyCode.Z))
            {
                atk1 = true;
                
            }
        //}
        
        if(Input.GetKeyUp(KeyCode.Z))
        {
            atk1 = false;
        }
        
        
    }
    private void FixedUpdate()
    {
        if (roll)
        {
            cm.Roll();
            rollTimer = rollInterval;
            roll = false;
            //Debug.Log("called roll");
            //rollTimer = rollInterval;
        }
        
        cm.Move();
        if (atk1)
        {
            pa.Attack1();
            //atkTimer = atkInterval;
            atk1 = false;
        }
      
    }
}
