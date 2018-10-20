using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Motion : MonoBehaviour {

    private Animator anim;
    private CharacterController controller;
    public float speed = 6.0f;
    public float turnSpeed = 100.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        // Animation v-- Below --v 
        // anim.SetInteger("AnimPar", 0); ----> Idle
        // anim.SetInteger("AnimPar", 1); ----> Move
        // anim.SetInteger("AnimPar", 2); ----> Attack

        if (controller.isGrounded)
        {
            // Moving direction.
            moveDirection = transform.right * Input.GetAxis("Vertical") * speed; 
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime,0);
        controller.Move(moveDirection * Time.deltaTime);
        
       
        
	}

}
