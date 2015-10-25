using UnityEngine;
using System.Collections;

public class FireballAI : MonoBehaviour {

	public int attackDamage;
	private BoxCollider2D collider;
	private Rigidbody2D FireballRB;
	private Animator anim;
	
	private double destroyDistance; // Max distance between fireball and player, if exceeded the fireball will be destroyed. 
	private GameObject mob;
	private GameObject Player;
	private Rigidbody2D mobRB;

	Health pHealth;
	
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>(); 
		mob = GameObject.Find ("Flower");
		Player = GameObject.Find ("Player");
		mobRB = mob.GetComponent<Rigidbody2D> ();
		FireballRB = GetComponent<Rigidbody2D> ();
		pHealth = Player.GetComponent<Health> ();
		destroyDistance = 5.0F;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		if (ExceedMaxDistance ())
			Destroy (gameObject);
	}
	
	private bool ExceedMaxDistance() {
		float currentDistance = Vector3.Distance (mobRB.position, FireballRB.position);
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