using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will connect all the references and serve as a bridge putting an enemy together
public class EnemyBase : MonoBehaviour
{
    //Required Components here - You can set these in the inspector, else they will be found automatically
    [SerializeField] EnemyHealth health = null;  //Reference to the enemy health script
    [SerializeField] EnemyMovement movement = null;  //Reference to the enemy movement script here
    [SerializeField] EnemyAttack attack = null; //Reference to the enemy attack 

    //private variables used to store current state information
    bool isDead = false;

    // Start is called before the first frame update
    void Awake()
    {
        //If any of the required components are missing, try to find them
        if (!health)
        {
            health = GetComponent<EnemyHealth>();
        }
        if (!movement)
        {
            movement = GetComponent<EnemyMovement>();
        }
        if (!attack)
        {
            attack = GetComponent<EnemyAttack>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the enemy is dead, if so set the bool and do stuff based on this bool
        if(health.health <= 0)
        {
            isDead = true;  //You can use this for dead shenanigans
        }

        //Checks if the enemy can attack
        if (attack.canAttack())
        {

            attack.attack();
        }

    }

    //Handle the physics here, like movement
    private void FixedUpdate()
    {
        //Checks if the enemy can move, move is so
        if (movement.canMove())
        {
            movement.move();
        }
    }


}
