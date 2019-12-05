using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] int maxCount
    {
        get { return maxCount; }
        set { maxCount = value; }
    }

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
        if (this.count + count < maxCount)
        {
            this.count += count;
        }
        else
        {
            this.count += (maxCount - count);
        }
    }
}
