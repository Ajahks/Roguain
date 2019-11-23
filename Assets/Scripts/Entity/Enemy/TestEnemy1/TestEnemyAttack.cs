using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAttack : EnemyAttack
{
    //Attack cooldown timers here
    float attackCooldownTime = 3.0f;
    float attackCooldownTimer = 0.0f;
    
    //We will define the actual attack here. Note: if it has to do with the physics, then we will just set bools here and handle the physics in FixedUpdate
    public override void attack()
    {
        attackCooldownTimer = attackCooldownTime;
        Debug.Log("Punch");
    }

    //Handle how we can check if the enemy can attack or not here
    public override bool canAttack()
    {
        //Check if the attack is on cooldown
        if(attackCooldownTimer > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //Here we will handle the timers
    private void Update()
    {
        //If the attack is on cooldown, then tick it down
        if(attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }
}
