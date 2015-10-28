using UnityEngine;
using System.Collections;

public class ExplosionAttackAI : MonoBehaviour {
	
	GameObject player;
	Health pHealth;
	EnemyStats eStats;
	int attackDamage;
	
	void Start() {

		eStats = GetComponent<EnemyStats> ();
		attackDamage = eStats.GetAttackDamage ();
		player = GameObject.Find ("Player");
		pHealth = player.GetComponent<Health> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			//print ("Collision");
			Attack();
			pHealth.TakeDamage (attackDamage);

		}
	}
	/** Enemy attack with sucidebomber */
	void Attack() {
		eStats.Die ();
	}

}
