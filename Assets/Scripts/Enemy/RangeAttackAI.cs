using UnityEngine;
using System.Collections;

public class RangeAttackAI : MonoBehaviour {
	
	public int force;
	public float firingRange;
	public Rigidbody2D prefab;
	private GameObject player;
	private float fireBallStart = 0f;
	public float fireBallCooldown = 0.5f;	// 0.5 seconds
	private float rangeToPlayer;
	private EnemyStats mobHealth; 
	
	void Start() {
		player = GameObject.Find("Player");
		mobHealth = GetComponent<EnemyStats> ();
	}

	// Update is called once per frame
	void Update () {
		rangeToPlayer = Vector2.Distance (transform.position, player.transform.position);
		if (rangeToPlayer <= firingRange && Time.time > fireBallStart + fireBallCooldown) {
			if (mobHealth.getHealth() > 0) {
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
		fireball.AddForce(targetDirection * force);
	}
}