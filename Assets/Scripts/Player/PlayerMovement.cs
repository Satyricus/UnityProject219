using System;
using UnityEngine;
using System.Collections;

/*
* This script is responsible for the movement of the player through the RigidBody2D component.
*
* further reading on RigidBody2D: http://docs.unity3d.com/ScriptReference/Rigidbody2D.html
*/
public class PlayerMovement : MonoBehaviour {

	public int speed = 1;

	Rigidbody2D rbody;	// Player rigidbody
	Animator anim;		// Player amimator
    private bool isLocked;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	    isLocked = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (isLocked)
	        return;


		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));	// getAxisRaw = bool
		if (movement_vector != Vector2.zero) {	// Player is moving
			anim.SetBool ("isWalking", true);
			anim.SetFloat("inputX", movement_vector.x);
			anim.SetFloat("inputY", movement_vector.y);
		} else {
			anim.SetBool("isWalking", false);
		}

		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * speed);	// Move player's rigidbody
	}

    public void LockPlayer()
    {
        isLocked = true;
    }

    public void UnlockPlayer()
    {
        isLocked = false;
    }
}
