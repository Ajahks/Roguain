using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private int count
    {
        get { return count; }
        set { count = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // increases the copies of items
    public void IncreaseCount(int count)
    {
        this.count += count;
    }
}
