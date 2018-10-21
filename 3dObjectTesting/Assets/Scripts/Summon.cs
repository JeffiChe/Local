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
        for(int i = 0; i < 3;i++)
        {
            Transform loca = MonsterLocations.locations[i];
            GameObject mon = (GameObject)Instantiate(monster, new Vector3(loca.position.x,0.25f,loca.position.z), loca.rotation);
            mon.transform.Rotate(new Vector3(0f, 0f, 0f), Space.Self);
            mon.tag = "Ally";
            monsters[i] = mon;
            monsterNumber++;

        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
