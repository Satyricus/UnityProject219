﻿using UnityEngine;
using System.Collections;

/*
* This script is responsible for enemy AI. 
*
* As of now it will be "guarding" it's spawn location, get too close to it's spawn location and it will follow you.
* Run away from it and once you've put some distance, the enemy will retreat back to spawn location. 
*/

public class SimpleEnemyAI : MonoBehaviour
{
	
    GameObject player;
    float rangeToTarget;
	Transform target;
	Animator anim;
	Vector3 spawnLocation;

	float threshold = 0.5f;

    public float speed;
	public float aggroRadius;

    public int attackDamage;

    private GameObject _playerManager;
    private PlayerManager playerManager;

	void Start () 
	{

		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator> ();
		spawnLocation = transform.position;
		//body = GetComponent<Rigidbody2D>();
		anim.SetBool ("isWalking", false); // Shouldnt be needed, but moves otherwise.

        _playerManager = GameObject.Find("_PlayerManager");
        playerManager = _playerManager.GetComponentInChildren<PlayerManager>();

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

		rangeToTarget = Vector3.Distance (transform.position, target.position);	// Distance from enemy to target.
		threshold = Vector3.Distance (transform.position, spawnLocation);		// Are we close to spawn location.

		if (threshold <= 0.05f && rangeToTarget > aggroRadius) {	// Stand on spawn location.

			//print ("#4");
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);

		} else if (rangeToTarget <= .5f) {	// Close to target, stop moving and attack.

			//print ("#1");
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);
			Attack ();	// TODO: implement attack.

		} else if (rangeToTarget < aggroRadius) {	// If player is in (aggro) range, move towards player.

			//print ("#2");
			Vector3 targetDirection = target.position - transform.position;
			transform.position += targetDirection.normalized * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true);
			anim.SetFloat("ValueX", targetDirection.x);
			anim.SetFloat("ValueY", targetDirection.y);

		} else if (rangeToTarget > aggroRadius) {	// Player is out of range, return to spawn location.

			//print ("#3");
			Vector3 targetDirection = spawnLocation - transform.position;
			transform.position += targetDirection.normalized * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true); // Might not need.
			anim.SetFloat("ValueX", targetDirection.x);
			anim.SetFloat("ValueY", targetDirection.y);

		}
	}

    // Decreases the players health.
	void Attack()
	{
	    playerManager.playerHealth -= attackDamage; // Forgive the shitty code, will fix later.
	}

    void OnCollisionStay2D(Collision2D col)
    {
        
    }
}
