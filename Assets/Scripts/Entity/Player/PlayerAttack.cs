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
        if(timerAtkCombo1Reset > 0)
        {
            timerAtkCombo1Reset -= Time.deltaTime;
        }
        else
        {
            atkCountCombo1 = 0;
        }
        if(timerCollide > 0)
        {
            timerCollide -= Time.deltaTime;
        }
        else
        {
            box.offset = new Vector2(0, 0);
        }
        if(timer > 0)
        {
            canAtk = false;
            timer -= Time.deltaTime;
            
            //gameObject.SetActive(false);
        }
        else
        {
            canAtk = true;
            
        }
    }

    public void Attack1()
    {
        if (canAtk)
        {
            gameObject.SetActive(true);

            if (atkCountCombo1 == 3)
            {
                atkCountCombo1 = 0;
            }
            if (sr.flipX == false)
            {
                box.offset = new Vector2(xOffset, 0);
            }
            else
            {
                box.offset = new Vector2(-xOffset, 0);
            }

            if (atkCountCombo1 == 2)
            {
                timer = atkTimeCombo1Finish;
                state = State.combo1Finish;
            }
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
