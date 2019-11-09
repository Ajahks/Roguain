using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // Health related
    public int initialHealth = 100;
    public int health;

    // Is the player dead or not?
    public bool isDead;

    // To modify upon death
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        health = initialHealth;

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            isDead = true;
            sr.enabled = false;
        }
    }
}
