using System;
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

	[SerializeField] private String hearthStoneKey;

	private Vector2 direction; // Will be used to get the direction the player is facing for range attacks or other purposes. 

	// Use this for initialization
	void Start () {
		pause = GetComponentInParent<GamePause> ();
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetBool ("isWalking", false); // Player start at idle
		direction = new Vector2(0,1); // Players starting direction
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Detecting and removing Fog of war
		Collider2D [] fogs = Physics2D.OverlapCircleAll(transform.position,2.5f);
		foreach (Collider2D fog in fogs) {
			if (fog.gameObject.CompareTag ("FOW"))
				Destroy (fog.gameObject);
		}
		//if (pause.GetPausStatus ())
			//return;

		if (Input.GetKeyDown(hearthStoneKey))
			Application.LoadLevel(2);

		Vector2 movement_vector = Vector2.ClampMagnitude(new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")),1);	// getAxisRaw = bool


		if (!movement_vector.Equals(new Vector2(0,0)))
			direction = movement_vector;


		if (movement_vector != Vector2.zero) {	// Player is moving
			anim.SetBool ("isWalking", true);
			anim.SetFloat("inputX", movement_vector.x);
			anim.SetFloat("inputY", movement_vector.y);
		} else {
			anim.SetBool("isWalking", false);
		}
		//movement_vector = Vector2.ClampMagnitude (movement_vector, 1.1f);
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * speed);	// Move player's rigidbody
	}


	public Vector2 GetDirection() {
		return direction;
	}
	/**
	 * Using haste
	 @param speed: haste movement speed*/
	public void setMovementSpeed(int speed){
		this.speed = speed;
	}
}
