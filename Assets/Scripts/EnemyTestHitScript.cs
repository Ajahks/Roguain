using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestHitScript : MonoBehaviour
{
    public EnemyTestStat stat;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<EnemyTestStat>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "PlayerAttack")
        //{
        //    stat.Health--;
        //    if(stat.Health <= 0)
        //    {
        //       sr.material.color = Color.black;
        //    }
        //    else
        //    {
        //        StartCoroutine(BlinkRed());
        //    }
            

            
        //}
    }
    public IEnumerator BlinkRed()
    {
        sr.material.color = Color.red;
        yield return new WaitForSeconds(.1f);
        sr.material.color = Color.white;
    }
}
