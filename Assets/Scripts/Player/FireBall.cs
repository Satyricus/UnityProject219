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

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Enemy")) {
			print ("Hit!");
			var EnemyHealth = other.GetComponent<EnemyHealth>();
			EnemyHealth.TakeDamage(attackDamage);
		}
	}
}
