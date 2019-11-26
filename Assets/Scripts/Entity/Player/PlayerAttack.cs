using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    BoxCollider2D box;
    float xOffset = 0.7f;
    float timer = 0;
    float timerCollide = 0;
    float timerAtkCombo1Reset = 0;
    float atkCombo1ResetTime = .5f;
    float collideTime = .1f;
    public float atkTimeCombo1 = 0.175f;
    public float atkTimeCombo1Finish = .435f;
    bool canAtk = true;
    bool canTrigger = false;
    //bool combo1 = false;
    //bool combo1Finish = false;
    int atkCountCombo1 = 0;
    SpriteRenderer sr;

    public State state;

    public enum State
    {
        combo1,
        combo1Finish,
        none,
    }


    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sr = GetComponentInParent<SpriteRenderer>();
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if you attack once, check for next attack
        if(timerAtkCombo1Reset > 0)
        {
            timerAtkCombo1Reset -= Time.deltaTime;
        }
        // if next attack not in time, resets combo
        else
        {
            atkCountCombo1 = 0;
        }

        // time for the collider to hit target
        if(timerCollide > 0)
        {
            canTrigger = true;
            timerCollide -= Time.deltaTime;
        }
        // collider recedes backwards
        else
        {
            canTrigger = false;
            box.offset = new Vector2(0, 0);
        }

        // length of time for the attack
        if(timer > 0)
        {
            canAtk = false;
            timer -= Time.deltaTime;
            
        }
        // can attack now
        else
        {
            canAtk = true;
            
        }
    }

    public void Attack1()
    {
        if (canAtk)
        {
            //gameObject.SetActive(true);

            // reset combo after 3 hits
            if (atkCountCombo1 == 3)
            {
                atkCountCombo1 = 0;
            }
            // if facing right, attack to the right
            if (sr.flipX == false)
            {
                box.offset = new Vector2(xOffset, 0);
            }
            // if facing left, attack to the left
            else
            {
                box.offset = new Vector2(-xOffset, 0);
            }

            // third attack of the combo sets longer cooldown and higher damage
            if (atkCountCombo1 == 2)
            {
                timer = atkTimeCombo1Finish;
                state = State.combo1Finish;
            }
            // normal cooldown and damage
            else
            {
                timer = atkTimeCombo1;
                state = State.combo1;
            }
            atkCountCombo1++;
            canTrigger = true;
            timerCollide = collideTime;
            timerAtkCombo1Reset = atkCombo1ResetTime;
        }
    }
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Enemy" && canTrigger)
        {
            canTrigger = false;
            EnemyTestHitScript test = enemy.gameObject.GetComponent<EnemyTestHitScript>();
            if (state == State.combo1)
            {
                test.stat.Health--;
            }
            else if(state == State.combo1Finish)
            {
                test.stat.Health -= 3;
            }
            state = State.none;
            if(test.stat.Health <= 0)
            {
                test.sr.material.color = Color.black;
            }
            else
            {
                StartCoroutine(test.BlinkRed());
            }
        }
    }
}
