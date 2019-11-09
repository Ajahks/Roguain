using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    BoxCollider2D box;
    float xOffset = 0.7f;
    float timer = 0;
    public float atkTime = 0.2f;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sr = GetComponentInParent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            gameObject.SetActive(false);
        }
    }

    public void Attack()
    {
        if (sr.flipX == false)
        {
            box.offset = new Vector2(xOffset, 0);
        }
        else
        {
            box.offset = new Vector2(-xOffset, 0);
        }
        gameObject.SetActive(true);

        timer = atkTime;
    }
    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "[some enemy tag]")
        {
            Debug.Log("enemy successfully hit " + enemy.name);
        }
    }
}
