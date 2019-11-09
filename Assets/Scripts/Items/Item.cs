using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private string name;

    public Item(string name)
    {
        this.name = name;
    }

    // increases the copies of items
    public void IncreaseCount(int count)
    {
        this.count += count;
    }
}
