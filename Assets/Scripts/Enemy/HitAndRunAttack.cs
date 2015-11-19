using UnityEngine;
using System.Collections;

/** This script is for enemies who attack via hitting the player and then retreating a short distance. This also covers enemy movement (moveToPlayer) */
public class HitAndRunAttack : MonoBehaviour {

	GameObject player;
	Vector3 target;
	Vector3 runTo;
	Animator anim;
	Vector3 spawnLocation;
	EnemyStats eStats;
	SpriteRenderer spriteRender;
	
	private float threshold = 0.5f;	// Used as a episolon/delta to calculate margin for error.
	private float rangeToTarget;
	public float speed;
	public float aggroRadius;
	public bool debug; // Set to true for debugging with print statements.
	public float attackRange;

	public Rigidbody2D scratchAnim;	// The prefab for the attack animation.
	Rigidbody2D scratch;

	// Time between attacks
	private float attackStart = 0;
	public float attackCD = 1.5f; // 1.5 seconds.
	private bool hasAttacked = false;
	private bool isInvisible = false; 
	private float invisStart = 0;
	private float invisStop = 0;
	private float invisCD = 2.0f; 
	private float invisTime = 1.0f;

	private int attackDamage;

	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		spriteRender = GetComponent<SpriteRenderer> (); 
		anim = GetComponent<Animator> ();
		spawnLocation = transform.position;
		eStats = GetComponent<EnemyStats>();
		anim.SetBool ("isWalking", false);
		attackDamage = eStats.GetAttackDamage ();
	}
	
	
	// Called once per frame.
	void Update() {
		// TODO: Fix paused status
		//if (pause.GetPausStatus ()|| isLocked)
		//	return;
		
		// TODO: if (playerHealth <= 0;
		if (Time.time > attackStart + attackCD) {
			hasAttacked = false;
		}

		target = player.transform.position;
		if(debug)
			Debug.DrawLine (transform.position, target, Color.yellow);
		rangeToTarget = Vector3.Distance (transform.position, target);	// Distance from enemy to target.
		threshold = Vector3.Distance (transform.position, spawnLocation);		// Are we close to spawn location.
		if (debug)
			print ("rangetoTarget = " + rangeToTarget);
		if (this.name.Contains ("Ghost")) {
			if ((Time.time > invisStop + invisCD) && !isInvisible) {
				GhostEnableInvisible ();
			} 
			if ((Time.time > invisStart + invisTime) && isInvisible) {
				GhostDisableInvisible ();
			}
		}
		if (!hasAttacked) {	// Bat can move towards player to attack.
			if (threshold <= 0.05f && rangeToTarget > aggroRadius) {	// Stand on spawn location.
				if (debug)
					print ("Far away, will not attack.");
				transform.position = transform.position;
				anim.SetBool ("isWalking", false);
			
			} else if (rangeToTarget <= attackRange) {	// Close to target, stop moving and attack.
				if (debug)
					print ("Target is close, doesn't need to move.");
				transform.position = transform.position;
				anim.SetBool ("isWalking", false);
				FindRunToCoods ();
				Attack ();
			
			} else if (rangeToTarget < aggroRadius) {	// If player is in (aggro) range, move towards player.
				// if mob is dead.
				if (eStats.getHealth () <= 0) {
					return;
				}
				if (debug)
					print ("Move towards player.");
				Vector3 targetDirection = target - transform.position;
				transform.position += targetDirection.normalized * speed * Time.deltaTime;
				// Update animator.
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("valueX", targetDirection.x);
				anim.SetFloat ("valueY", targetDirection.y);
			
			} else if (rangeToTarget > aggroRadius) {	// Player is out of range, return to spawn location.
				// if mob is dead.
				if (eStats.getHealth () <= 0) {
					return;
				}
				if (debug)
					print ("Player out of range, return to spawn location. ");
				Vector3 targetDirection = spawnLocation - transform.position;
				transform.position += targetDirection.normalized * speed * Time.deltaTime;
				// Update animator.
				anim.SetBool ("isWalking", true); // Might not need.
				anim.SetFloat ("valueX", targetDirection.x);
				anim.SetFloat ("valueY", targetDirection.y);
			}
		} else { // The run part of hit&run.
			Vector3 targetDirection = runTo - transform.position;
			transform.position += targetDirection.normalized * speed * Time.deltaTime;
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("valueX", targetDirection.x);
			anim.SetFloat ("valueY", targetDirection.y);
		}
	}

	/** This method controls the attack logic for hit&run enemies. */
	void Attack() {
		attackStart = Time.time;
		hasAttacked = true;
		player.GetComponent<Health>().TakeDamage(attackDamage);
		scratch = Instantiate(scratchAnim, player.transform.position, Quaternion.identity) as Rigidbody2D;	// Instatiate the attack animiation.
	}

	/** Sets the coordinate for where the enemy should run to after it has attacked. */
	void FindRunToCoods () {
		float xPos = 0;
		float yPos = 0;
		while (xPos == 0 && yPos == 0) {	// We do not want 0,0 (enemy will not move).
			xPos = RandomGenerator();
			yPos = RandomGenerator();
		}
		runTo = new Vector3 (player.transform.position.x + xPos*10, player.transform.position.y + yPos*10, 0);
	}

	/** Generates a random number between -1 and 1. Used for a random runTo location */
	int RandomGenerator() {
		return Random.Range (-1, 2);
	}
	void GhostEnableInvisible(){
		invisStart = Time.time;
		isInvisible = true;
		spriteRender.enabled = false;
	}
	void GhostDisableInvisible(){
		invisStop = Time.time;
		isInvisible = false;
		spriteRender.enabled = true;
	}


}
