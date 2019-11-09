using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLists : MonoBehaviour {

    private List<GameObject> enemies;
    public int enemiesKilled;

	// Use this for initialization
	void Start () {
        enemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<GameObject> getEnemies()
    {
        return enemies;
    }
}
