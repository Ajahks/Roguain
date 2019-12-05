/* This is the class for Inventory that contains Lists that hold Items. The methods are left generic
 * so that all items can pass through and go into their respective lists.
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int HAIR_LIMIT = 3; // inventory limit for hairs
    public const int INV_LIMIT = 10; // main inventory limit

    public List<Item> hairList = new List<Item>( HAIR_LIMIT ); // holds hair powerups
    public List<Item> mainInventory = new List<Item>( INV_LIMIT ); // holds hair powerups

    // adds item to inventory
    public void AddItem( List<Item> list, Item item )
    {
        if ( list.Contains( item ) )
        {
            list[list.IndexOf( item )].IncreaseCount( 1 );
        }

        // checks if list is full
        else if ( list.Count == list.Capacity )
        {
            System.Console.WriteLine( "Inventory full." );
            return;
        }

        else
        {
            list.Add( item );
        }
    }

    // removes item from inventory
    public void RemoveItem( List<Item> list, Item item )
    {
        // removes item when found
        if ( list.Contains( item ) )
        {
            list.RemoveAt( list.IndexOf( item ) );
        }
    }
}
