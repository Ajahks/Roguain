using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 10; // # of item spaces

    public List<Item> list = new List<Item>();

    // adds item to inventory
    private void AddItem(Item item)
    {
        // adds item if there is space
        if (list.Count < space)
        {
            list.Add(item);
        }

        // tells player that item couldn't be added
        System.Console.WriteLine("Inventory full.");
    }

    private void RemoveItem(Item item)
    {
        // iterates through the inventory
        for (int index = 0; index < list.Count; index++)
        {
            // removes item when found
            if (list.Contains(item))
            {
                list.RemoveAt(index);
            }
        }
    }
}
