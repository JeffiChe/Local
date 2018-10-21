using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour {

    public GameObject monster;
    public GameObject[] monsters;
    private int monsterNumber = 0;

    // Use this for initialization
    void Start()
    {
        monsters = new GameObject[30];
        for (int i = 0; i < 1; i++)
        {
            Transform loca = EnemyLocations.locations[i];
            GameObject mon = (GameObject)Instantiate(monster, new Vector3(loca.position.x, 0.25f, loca.position.z), loca.rotation);
            mon.transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            mon.AddComponent<EnemyMonsters>();
            Destroy(mon.GetComponent("Monster"));
            mon.tag = "Enemy";
            monsters[i] = mon;
            monsterNumber++;

        }

    }
}
