using UnityEngine;
using System.Collections;

/*
* This script is responsible for enemy AI. 
*
* As of now it will be "guarding" it's spawn location, get too close to it's spawn location and it will follow you.
* Run away from it and once you've put some distance, the enemy will retreat back to spawn location. 
*/

class SimpleEnemyAI : MonoBehaviour
{
	GamePause pause;
    GameObject player;
    float rangeToTarget;
	Transform target;
	Animator anim;
	Vector3 spawnLocation;

	public bool isLocked;

	float threshold = 0.5f;

	[Range (0,10)]
    public float speed;
	public float aggroRadius;
    public int attackDamage;

    private Health health;

	void Start () 
	{
		pause = GetComponentInParent<GamePause> ();
		player = GameObject.Find("Player");
		anim = GetComponent<Animator> ();
		spawnLocation = transform.position;
		//body = GetComponent<Rigidbody2D>();
		anim.SetBool ("isWalking", false); // Shouldnt be needed, but moves otherwise.

        health = player.GetComponentInChildren<Health>();

		isLocked = false;

    }
	
	


	// Called once per frame.
	void FixedUpdate() {
		// TODO: Fix paused status
		//if (pause.GetPausStatus ()|| isLocked)
		//	return;

		// TODO: if (playerHealth <= 0)
		target = player.transform;

		// Temp, for debugging.
		//Debug.DrawLine (transform.position, target.position, Color.yellow);

		rangeToTarget = Vector3.Distance (transform.position, target.position);	// Distance from enemy to target.
		threshold = Vector3.Distance (transform.position, spawnLocation);		// Are we close to spawn location.

		if (threshold <= 0.05f && rangeToTarget > aggroRadius) {	// Stand on spawn location.

			//print ("Far away, will not attack.");
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);

		} else if (rangeToTarget <= .5f) {	// Close to target, stop moving and attack.

			//print ("Target is close, doesn't need to move.");
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);
			Attack ();	

		} else if (rangeToTarget < aggroRadius) {	// If player is in (aggro) range, move towards player.

			print ("Move towards player.");
			Vector3 targetDirection = target.position - transform.position;
			transform.position += targetDirection.normalized * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true);
			anim.SetFloat("ValueX", targetDirection.x);
			anim.SetFloat("ValueY", targetDirection.y);

		} else if (rangeToTarget > aggroRadius) {	// Player is out of range, return to spawn location.

			//print ("");
			Vector3 targetDirection = spawnLocation - transform.position;
			transform.position += targetDirection.normalized * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true); // Might not need.
			anim.SetFloat("ValueX", targetDirection.x);
			anim.SetFloat("ValueY", targetDirection.y);

		}
	}

	public void LockGoblin() {
		isLocked = true;	
	}

	public void UnlockGoblin() {
		isLocked = false;
	}

    // Decreases the players health.
	void Attack()
	{
	    health.playerHealth -= attackDamage;
	}
	
}
