using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    
    Seeker seeker;

    private GameObject entityLists;

    private List<GameObject> enemyList;
    private List<GameObject> towerList;

    public Transform core;

    public float attackSpeed;
    private float lastAttack;

    private bool foundEnemy;

    public float health;

    private Animator anim;

	// Use this for initialization
	void Start () {
        entityLists = GameObject.FindGameObjectWithTag("EntityList");
        enemyList = entityLists.GetComponent<EntityLists>().getEnemies();
        enemyList.Add(gameObject);

        seeker = gameObject.GetComponent<Seeker>();

        core = GameObject.FindGameObjectWithTag("Core").transform;

        seeker.StartPath(transform.position, core.position, OnPathComplete);

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        lastAttack += Time.deltaTime;

        if (getDistanceTo(core.gameObject)<3&&lastAttack>attackSpeed)
        {
            lastAttack = 0;

            // core.gameObject.GetComponent<CoreScript>().dealDamage(5);

            anim.SetTrigger("Attack");
        }

	

        

	}

    public void OnPathComplete(Path p)
    {
        if (p.error)
        {
            
        } else
        {
            seeker.StartPath(transform.position, core.position, OnPathComplete);
            /*float minDistance = Mathf.Infinity;
            Transform closeTarget = null;

            foreach (GameObject t in towerList)
            {
                if (getDistanceTo(t) < minDistance)
                {
                    minDistance = getDistanceTo(t);
                    closeTarget = t.transform;
                }
            }

            if (closeTarget != null)
            {
                seeker.StartPath(transform.position, closeTarget.position);
            }*/
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health--;

            if (health <= 0)
            {
                entityLists.GetComponent<EntityLists>().enemiesKilled++;
                // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().mana += 20 / GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>().waveNumber;
                enemyList.Remove(gameObject);
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.tag == "Player" && lastAttack > attackSpeed)
        {
            lastAttack = 0;
            // collision.gameObject.GetComponent<PlayerScript>().dealDamage(5);
            anim.SetTrigger("Attack");
        }
    }

    float getDistanceTo(GameObject otherGameObject)
    {
        return Vector2.Distance(transform.position, otherGameObject.transform.position);
    }
}
