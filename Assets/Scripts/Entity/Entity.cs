using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int damage;
    //add any other shared stats or functions between all entities (playable char, enemy, boss, etc)
    //also this can be used to only contain the stats so we can break up the code into more scripts like Arren said, in which case we dont need it to inherit anything

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

}
