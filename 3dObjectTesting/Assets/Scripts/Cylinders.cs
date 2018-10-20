using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinders : MonoBehaviour {

    public static Transform[] cylinders;

    void Start()
    {
        
    }
    private void Awake()
    {
        cylinders = new Transform[transform.childCount];
        for (int i = 0; i < cylinders.Length; i++)
        {
            cylinders[i] = transform.GetChild(i);
        }
    }
}
