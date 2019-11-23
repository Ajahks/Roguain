using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will handle the movement of the enemy - This is an abstract class as each enemy type can have different movement options
//Feel free to add or edit any of these methods to your likings :)
public abstract class EnemyMovement : MonoBehaviour
{
    //Determines whether or not the enemy can move 
    public abstract bool canMove();

    public abstract void move();
}
