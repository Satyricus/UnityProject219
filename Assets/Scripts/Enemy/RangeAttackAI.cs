using UnityEngine;
using System.Collections;

public class RangeAttackAI : MonoBehaviour {
	
	public int force;
	public float firingRange;
	public Rigidbody2D prefab;
	public float fireBallCooldown = 0.5f;	// 0.5 seconds

	private GameObject player;
	private float fireBallStart = 0f;
	private float rangeToPlayer;
	private EnemyStats stats; 
	private int attackDamage;
	
	void Start() {
		player = GameObject.Find("Player");
		stats = GetComponent<EnemyStats> ();
	}

	// Update is called once per frame
	void Update () {
		rangeToPlayer = Vector2.Distance (transform.position, player.transform.position);
		if (rangeToPlayer <= firingRange && Time.time > fireBallStart + fireBallCooldown) {
			if (stats.getHealth() > 0) {
				fireBallStart = Time.time;
				SpawnAttack();
			}
		}
	}	
	/**
	 * Spawn a fireball from enemy in players direction */
	void SpawnAttack() {
		Vector2 targetDirection = player.transform.position - transform.position;
		Rigidbody2D fireball = Instantiate(prefab, transform.position, Quaternion.identity) as Rigidbody2D;
		fireball.transform.parent = transform;	// Spawn as child object.
		attackDamage = stats.GetAttackDamage ();
		fireball.GetComponent<FireballAI> ().SetAttackDamage (attackDamage);
		fireball.GetComponent<Rigidbody2D>().AddForce(targetDirection * force);
	}
}