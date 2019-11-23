using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an abstract class that all enemy attack scripts should grab from.  Feel free to add anything to this
public abstract class EnemyAttack : MonoBehaviour
{

    //Basic function for attack
    public abstract void attack();

    //Returns bool telling if an enemy can attack or not.  The child class can use a timer or some other method of determining if it can attack
    public abstract bool canAttack();
}
