using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsters : MonoBehaviour {

    public int healthpoint = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (healthpoint <= 0)
        {
            Destroy(gameObject);
        }
	}
    
    void HPDeduction(int i)
    {
        healthpoint -= i;
    }
}
