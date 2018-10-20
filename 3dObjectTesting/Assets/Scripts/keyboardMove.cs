using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardMove : MonoBehaviour {
    private Vector2 targetPos;
    public float Yincrement;
    public float Xincrement;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
            transform.position = targetPos;
        }   else if (Input.GetKeyDown(KeyCode.RightArrow)){
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
            transform.position = targetPos;
        }

    }
}
