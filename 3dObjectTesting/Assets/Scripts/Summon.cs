using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour {

    public GameObject monster;
    public GameObject[] monsters;
    private int monsterNumber=0;

	// Use this for initialization
	void Start () {
        monsters = new GameObject[30];
        for(int i = 0; i < 1;i++)
        {
            Transform loca = MonsterLocations.locations[i];
            GameObject mon = (GameObject)Instantiate(monster, loca.position, loca.rotation);
            mon.AddComponent<CharacterController>();
            if (i==1) { mon.tag = "Enemy"; }

                
            monsters[i] = mon;
            monsterNumber++;

        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
