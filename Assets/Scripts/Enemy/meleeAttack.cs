using UnityEngine;
using System.Collections;

public class meleeAttack : MonoBehaviour {
	private int attackDamage;
	Animator anim;
	GameObject player;
	EnemyStats estats;
	private float attackStart;
	private float attackCD;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = GetComponent<Animator> ();
		estats = GetComponent<EnemyStats> ();
		attackCD = 1.0f;
		attackStart = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetBool ("isAttacking") && Time.time > attackStart + attackCD) {
			attackDamage = estats.GetAttackDamage();
			attackStart = Time.time;
			player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
		}
	}
}
