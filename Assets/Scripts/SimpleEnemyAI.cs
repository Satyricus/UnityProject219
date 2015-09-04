using UnityEngine;
using System.Collections;

/*
* This script is responsible for super simple AI, just placeholder AI.
*
*/

public class SimpleEnemyAI : MonoBehaviour
{
	
    GameObject player;
    float rangeToTarget;
	Transform target;
	Animator anim;
	Vector3 spawnLocation;

    public float speed;
	public float aggroRadius;

	void Start () 
	{

		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator> ();
		spawnLocation = transform.position;
		//body = GetComponent<Rigidbody2D>();
		anim.SetBool ("isWalking", false); // Shouldnt be needed, but moves otherwise.

	}
	
	
	void Update ()
	{

	}

	// Called once per frame.
	void FixedUpdate() {
		// TODO: if (playerHealth <= 0)
		target = player.transform;

		// Temp, for debugging.
		Debug.DrawLine (transform.position, target.position, Color.yellow);

		rangeToTarget = Vector3.Distance (transform.position, target.position);

		if (rangeToTarget <= .5f) {	// Close, stop moving and attack.
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);
			Attack ();	// TODO: implement attack.
		} else if (rangeToTarget < aggroRadius) {	// If player is in (aggro) range, move towards player.
			Vector3 targetDirection = target.position - transform.position;
			transform.position += targetDirection * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true);
			anim.SetFloat("ValueX", targetDirection.x);
			anim.SetFloat("ValueY", targetDirection.y);
		} else if (rangeToTarget > aggroRadius && transform.position != spawnLocation) {	// Player is out of range, return to spawn location.
			Vector3 targetDirection = spawnLocation - transform.position;
			transform.position += targetDirection * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true); // Might not need.
			anim.SetFloat("ValueX", targetDirection.x);
			anim.SetFloat("ValueY", targetDirection.y);
		} else {	// Stand on spawn location.
			print ("Here");
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);
		}
	}

	void Attack() {

	}
}
