using UnityEngine;
using System.Collections;

public class FireballAI : MonoBehaviour {

	public int attackDamage;
	private BoxCollider2D collider;
	private Rigidbody2D FireballRB;
	private Animator anim;
	private double destroyDistance; // Max distance between fireball and player, if exceeded the fireball will be destroyed. 
	private GameObject Player;
	private Vector2 pos;
	Health pHealth;
	
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>(); 
		Player = GameObject.Find ("Player");
		FireballRB = GetComponent<Rigidbody2D> ();
		pHealth = Player.GetComponent<Health> ();
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
		float currentDistance = Vector2.Distance (pos, FireballRB.position);
		if (currentDistance >= destroyDistance) {
			return true;
		}
		return false;
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Player")) {
			pHealth.TakeDamage(attackDamage);
			GameObject.Destroy(gameObject);
		}
		if (coll.CompareTag ("Environment")) {
			GameObject.Destroy(gameObject);
		}
	}
}