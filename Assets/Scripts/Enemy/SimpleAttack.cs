using UnityEngine;
using System.Collections;

public class SimpleAttack : MonoBehaviour {

	EnemyStats stats;
	GameObject player;
	Health pHealth;

	GameObject statScaler; 
	Scaler scaler;
	int multiplier;
	
	EnemyStats eStats;

	int attackDamage;

	Animator anim;


	void Start() {

		eStats = GetComponent<EnemyStats> ();

		attackDamage = eStats.GetAttackDamage ();

		stats = GetComponent<EnemyStats> ();
		player = GameObject.Find ("Player");
		pHealth = player.GetComponent<Health> ();

		statScaler = GameObject.Find ("StatScaler");
		scaler = statScaler.GetComponent<Scaler> ();

		anim = GetComponent<Animator> ();

		multiplier = scaler.GetScale ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			print ("Collision");
			Attack();
			pHealth.TakeDamage (DoDamage ());

		}
	}

	void Attack() {
		eStats.Die ();

	}


	int DoDamage() {
		return stats.GetAttackDamage ();
	}
}
