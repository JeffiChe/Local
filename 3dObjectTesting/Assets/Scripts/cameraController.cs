﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime,Space.World);
        } else if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime,Space.World);
        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll *1000* scrollSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
