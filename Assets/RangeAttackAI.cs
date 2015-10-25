using UnityEngine;
using System.Collections;

public class RangeAttackAI : MonoBehaviour {
	
	public int force;
	public float firingRange;
	public Rigidbody2D prefab;
	private GameObject Player;
	private GameObject Flower;
	private PlayerMovement PMovement;
//	private FlowerMovement FMovement;
	private float fireBallStart = 0f;
	public float fireBallCooldown = 0.5f;	// 0.5 seconds
	private float rangeToPlayer;
	EnemyStats stats;
	Health pHealth;
	
	void Start() {
		Player = GameObject.Find("Player");
		Flower = GameObject.Find ("Flower");
		PMovement = Player.GetComponent<PlayerMovement>();
		stats = GetComponent<EnemyStats> ();
		pHealth = Player.GetComponent<Health> ();

	}

	// Update is called once per frame
	void Update () {
		rangeToPlayer = Vector3.Distance (transform.position, Player.transform.position);

		if (rangeToPlayer <= firingRange && Time.time > fireBallStart + fireBallCooldown) {
			fireBallStart = Time.time;
			SpawnAttack();
		}
	}	
	
	void SpawnAttack() {
		Vector2 targetDirection = Player.transform.position - transform.position;
		Rigidbody2D fireball = Instantiate(prefab, Flower.transform.position, Quaternion.identity) as Rigidbody2D;
		fireball.AddForce(targetDirection * force);
		//fireball.AddForce(PMovement.GetDirection() * force);
	}
	

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			print ("Collision");
			//pHealth.TakeDamage (DoDamage ());
			
		}
	}

	
	int DoDamage() {
		return stats.GetAttackDamage ();
	}
}