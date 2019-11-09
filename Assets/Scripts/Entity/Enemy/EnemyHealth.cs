using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int baseHealth = 100;
    public bool isDead;
    SpriteRenderer sr;


    public void damageEnemy(int damage)
    {
        health -= damage;
    }

    public void healEnemy()
    {
        sr.enabled = false;
    }

    public void kill()
    {
        isDead = true;
        sr.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = baseHealth;
        isDead = false;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            kill();
        }
    }
}
