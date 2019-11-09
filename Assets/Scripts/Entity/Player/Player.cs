using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //prob need slot for items/hair currently holding
    [SerializeField] Inventory inventory;

    void Start()
    {
        Name = "MC";
        Health = 5;
        Damage = 5;
        Speed = 5;

        //Get Inventory attached to player
        inventory = GetComponent<Inventory>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Add item to inventory
        if (collision.gameObject.tag == "Item")
        {
            inventory.AddItem(collision.gameObject);
        }
    }




}
