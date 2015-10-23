using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public int attackDamage;
	private BoxCollider2D collider;
	private Rigidbody2D FireballRB;
	private Animator anim;
	private PlayerMovement PMovement;

	private double destroyDistance; // Max distance between fireball and player, if exceeded the fireball will be destroyed. 
	private GameObject Player;
	private Rigidbody2D PlayerRB;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>(); 
		Player = GameObject.Find ("Player");
		PlayerRB = Player.GetComponent<Rigidbody2D> ();
		FireballRB = GetComponent<Rigidbody2D> ();
		PMovement = Player.GetComponent<PlayerMovement>();

		destroyDistance = 5.0F;
	}

//	void FixedUpdate() {
//		anim.SetFloat("inputX", PMovement.GetDirection().x);
//		anim.SetFloat("inputY", PMovement.GetDirection().y);
//	}
	
	// Update is called once per frame
	void Update () {

		if (ExceedMaxDistance ())
			Destroy (gameObject);
	}

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

	private void DoDamage(Collider2D coll) {
		var enemyStats = coll.GetComponent<EnemyStats>();
		enemyStats.TakeDamage(attackDamage);

		GameObject.Destroy(gameObject);
	}
}
