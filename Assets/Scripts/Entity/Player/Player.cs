using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //prob need slot for items/hair currently holding

    public float rollSpeed;

    private void Awake()
    {
        Title = "MC";
        Health = 5;
        Speed = 5;
        Damage = 5;
        rollSpeed = 50f;

    }
    
    



   
}
