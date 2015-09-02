using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rbody;	// Player rigidbody
	Animator anim;		// Player amimator

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));	// getAxisRaw = bool
		if (movement_vector != Vector2.zero) {	// Player is moving
			anim.SetBool ("isWalking", true);
			anim.SetFloat("inputX", movement_vector.x);
			anim.SetFloat("inputY", movement_vector.y);
		} else {
			anim.SetBool("isWalking", false);
		}

		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);	// Move player's rigidbody
	}
}
