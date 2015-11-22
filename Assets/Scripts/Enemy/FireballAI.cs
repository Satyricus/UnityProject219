using UnityEngine;
using System.Collections;

public class FireballAI : MonoBehaviour {

	private int attackDamage;
	private Rigidbody2D fireballRB;
	private double destroyDistance; // Max distance between fireball and player, if exceeded the fireball will be destroyed. 
	private GameObject player;
	private Vector2 pos;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		fireballRB = GetComponent<Rigidbody2D> ();
		destroyDistance = 5.0F;
		pos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (ExceedMaxDistance ())
			Destroy (gameObject);
	}
	/**
	 * return true if fireball has exceeded maximum distance
	 * return else if not
	 */
	private bool ExceedMaxDistance() {
		float currentDistance = Vector2.Distance (pos, fireballRB.position);
		if (currentDistance >= destroyDistance) {
			return true;
		}
		return false;
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Player")) {
			player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
			GameObject.Destroy(gameObject);
		}
		if (coll.CompareTag ("Environment")) {
			GameObject.Destroy(gameObject);
		}
	}

	public void SetAttackDamage(int damage) {
		attackDamage = damage;
	}
}