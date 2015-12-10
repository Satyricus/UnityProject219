using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {

	GameObject player;
	float rangeToTarget;
	Transform target;
	Animator anim;
	Vector3 spawnLocation;

	private float threshold = 0.5f;
	public float speed;
	public float aggroRadius;
	public bool debug; // Set to true for debugging with print statements
	public float attackRange;
	private EnemyStats eStats;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		anim = GetComponent<Animator> ();
		spawnLocation = transform.position;
		eStats = GetComponent<EnemyStats>();
		anim.SetBool ("isWalking", false);
		if (gameObject.name.StartsWith("Golem"))
			anim.SetBool ("isAttacking", false);
	}


	// Called once per frame.
	void Update() {
		// TODO: Fix paused status
		//if (pause.GetPausStatus ()|| isLocked)
		//	return;
		
		// TODO: if (playerHealth <= 0)
		target = player.transform;
		

		if(debug)
			Debug.DrawLine (transform.position, target.position, Color.yellow);

		rangeToTarget = Vector3.Distance (transform.position, target.position);	// Distance from enemy to target.
		threshold = Vector3.Distance (transform.position, spawnLocation);		// Are we close to spawn location.
		if (debug)
			print ("rangetoTarget = " + rangeToTarget);
		if (threshold <= 0.05f && rangeToTarget > aggroRadius) {	// Stand on spawn location.
			if(debug)
				print ("Far away, will not attack.");
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);
			if(gameObject.name.Contains("Golem"))
				anim.SetBool("isAttacking",false);

		} else if (rangeToTarget <= attackRange) {	// Close to target, stop moving and attack.
			if(debug)
				print ("Target is close, doesn't need to move.");
			if(gameObject.name.Contains("Golem"))
				anim.SetBool("isAttacking",true);
			transform.position = transform.position;
			anim.SetBool ("isWalking", false);

			//Attack ();	
			
		} else if (rangeToTarget < aggroRadius) {	// If player is in (aggro) range, move towards player.
			// if mob is dead.
			if(eStats.getHealth() <= 0) {
				return;
			}
			if(debug)
				print ("Move towards player.");
			Vector3 targetDirection = target.position - transform.position;
			transform.position += targetDirection.normalized * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true);
			anim.SetFloat("valueX", targetDirection.x);
			anim.SetFloat("valueY", targetDirection.y);
			if(gameObject.name.Contains("Golem"))
				anim.SetBool("isAttacking",false);
			
		} else if (rangeToTarget > aggroRadius) {	// Player is out of range, return to spawn location.
			// if mob is dead.
			if(eStats.getHealth() <= 0) {
				return;
			}
			if(debug)
				print ("Player out of range, return to spawn location. ");
			Vector3 targetDirection = spawnLocation - transform.position;
			transform.position += targetDirection.normalized * speed * Time.deltaTime;
			// Update animator.
			anim.SetBool ("isWalking", true); // Might not need.
			anim.SetFloat("valueX", targetDirection.x);
			anim.SetFloat("valueY", targetDirection.y);
			if(gameObject.name.Contains("Golem"))
				anim.SetBool("isAttacking",false);
			
		}
	}
}
