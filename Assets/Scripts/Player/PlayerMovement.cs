﻿using System;
using UnityEngine;
using System.Collections;

/*
* This script is responsible for the movement of the player through the RigidBody2D component.
*
* further reading on RigidBody2D: http://docs.unity3d.com/ScriptReference/Rigidbody2D.html
*/
public class PlayerMovement : MonoBehaviour {

	[Range (0,10)] // Makes the speed variable in the inspector a scrollbar from 0 to 10. 
	public int speed = 1;

	private Rigidbody2D rbody;	// Player rigidbody
	private Animator anim;		// Player amimator

	private GamePause pause;

	private Vector2 direction; // Will be used to get the direction the player is facing for range attacks or other purposes. 

	// Use this for initialization
	void Start () {
		pause = GetComponentInParent<GamePause> ();
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		direction = new Vector2();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (pause.GetPausStatus ())
			return;

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));	// getAxisRaw = bool


		if (!movement_vector.Equals(new Vector2(0,0)))
			direction = movement_vector;


		if (movement_vector != Vector2.zero) {	// Player is moving
			anim.SetBool ("isWalking", true);
			anim.SetFloat("inputX", movement_vector.x);
			anim.SetFloat("inputY", movement_vector.y);
		} else {
			anim.SetBool("isWalking", false);
		}

		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * speed);	// Move player's rigidbody
	}


	public Vector2 GetDirection() {
		return direction;
	}
}
