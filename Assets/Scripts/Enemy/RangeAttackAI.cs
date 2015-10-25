using UnityEngine;
using System.Collections;

public class RangeAttackAI : MonoBehaviour {
	
	public int force;
	public string nameOfEnemy;
	public float firingRange;
	public Rigidbody2D prefab;
	private GameObject Player;
	private GameObject mob;
	private float fireBallStart = 0f;
	public float fireBallCooldown = 0.5f;	// 0.5 seconds
	private float rangeToPlayer;
	
	void Start() {
		Player = GameObject.Find("Player");
		mob = GameObject.Find (nameOfEnemy);
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
		Rigidbody2D fireball = Instantiate(prefab, mob.transform.position, Quaternion.identity) as Rigidbody2D;
		fireball.AddForce(targetDirection * force);
	}
}