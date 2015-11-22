using UnityEngine;
using System.Collections;

public class ExplosionAttackAI : MonoBehaviour {

	public bool debug;

	GameObject player;
	EnemyStats eStats;
	int attackDamage;
	
	void Start() {

		eStats = GetComponent<EnemyStats> ();
		player = GameObject.Find ("Player");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			Attack();
			if (debug) {
				print (this.name + " tried to do " + attackDamage + " to player.");
			}
			attackDamage = eStats.GetAttackDamage ();
			player.GetComponent<PlayerStats>().TakeDamage (attackDamage);

		}
	}
	/** Enemy attack with sucidebomber */
	void Attack() {
		eStats.Die ();
	}

}
