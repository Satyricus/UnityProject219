using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public int attackDamage;
	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag("Enemy"))
			DoDamage(coll);
	}

	private void DoDamage(Collider2D coll) {
		var enemyHealth = coll.GetComponent<EnemyHealth>();
		enemyHealth.TakeDamage(attackDamage);

		GameObject.Destroy(gameObject);
	}
}
