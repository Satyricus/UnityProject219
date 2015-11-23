using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	private int attackDamage;
	private Rigidbody2D fireballRB;
	private double destroyDistance; // Max distance between fireball and player, if exceeded the fireball will be destroyed. 
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		fireballRB = GetComponent<Rigidbody2D> ();
		destroyDistance = 5.0F;
		attackDamage = player.GetComponent<PlayerStats>().AttackDamage;
	}

	// Update is called once per frame
	void Update () {
		if (ExceedMaxDistance ())
			Destroy (gameObject);
	}

	/**
	 * Return true if the fireball has exceeded maximum distance
	 * return false otherwise*/
	private bool ExceedMaxDistance() {
		float currentDistance = Vector2.Distance (player.GetComponent<Rigidbody2D>().position, fireballRB.position);
		if (currentDistance >= destroyDistance) {
			return true;
	}
		return false;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Enemy")) {
			DoDamage (coll);
		}
		else if (coll.CompareTag ("Environment")) {
			GameObject.Destroy (gameObject);
		} 
	}
	/**
	 * Do damage on enemy on impact*/
	private void DoDamage(Collider2D coll) {
		EnemyStats enemyStats = coll.GetComponent<EnemyStats>();
		enemyStats.TakeDamage(attackDamage);
		GameObject.Destroy(gameObject);
	}
}
