using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerAttack pa;
    CharacterMovement cm;
    bool roll, atk;
    float atkTimer = 0;
    float atkInterval = .5f;
    float rollTimer = 0;
    float rollInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        pa = GetComponentInChildren<PlayerAttack>();
        cm = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            roll = true;
        }
        else
        {
            roll = false;
        }
        if (atkTimer > 0)
        {
            atkTimer -= Time.deltaTime;
            atk = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                atk = true;
                
            }
        }
        
        if(Input.GetKeyUp(KeyCode.Z))
        {
            atk = false;
        }
        //if(rollTimer > 0)
        //{
        //    rollTimer -= Time.deltaTime;
        //}
        
    }
    private void FixedUpdate()
    {
        if (roll)
        {
            cm.Roll();
            //rollTimer = rollInterval;
        }
        
        cm.Move();
        if (atk)
        {
            pa.Attack();
            atkTimer = atkInterval;
        }
      
    }
}
