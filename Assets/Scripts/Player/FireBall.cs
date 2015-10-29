using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public int attackDamage;
	private Rigidbody2D FireballRB;
	private Animator anim;

	private double destroyDistance; // Max distance between fireball and player, if exceeded the fireball will be destroyed. 
	private GameObject Player;
	private Rigidbody2D PlayerRB;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		PlayerRB = Player.GetComponent<Rigidbody2D> ();
		FireballRB = GetComponent<Rigidbody2D> ();
		destroyDistance = 5.0F;
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
		float currentDistance = Vector3.Distance (PlayerRB.position, FireballRB.position);
		if (currentDistance >= destroyDistance) {
			return true;
	}
		return false;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag ("Enemy")) {
			DoDamage (coll);
		}
		if (coll.CompareTag ("Environment")) {
			GameObject.Destroy(gameObject);
		}
	}
	/**
	 * Do damage on enemy on impact*/
	private void DoDamage(Collider2D coll) {
		var enemyStats = coll.GetComponent<EnemyStats>();
		enemyStats.TakeDamage(attackDamage);

		GameObject.Destroy(gameObject);
	}
}
