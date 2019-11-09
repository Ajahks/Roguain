using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 10; // # of item spaces

    public List<Item> list = new List<Item>();

    // adds item to inventory
    public void AddItem(GameObject item)
    {
        // adds item if there is space
        if (list.Count < space)
        {
            list.Add(item.GetComponent<Item>());
        }

        // tells player that item couldn't be added
        System.Console.WriteLine("Inventory full.");
    }

    public void RemoveItem(GameObject item)
    {
        // iterates through the inventory
        for (int index = 0; index < list.Count; index++)
        {
            // removes item when found
            if (list.Contains(item.GetComponent<Item>()))
            {
                list.RemoveAt(index);
            }
        }
    }
}
