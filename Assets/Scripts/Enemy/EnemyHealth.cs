using UnityEngine;
using System.Collections;

/**
 * This script is responsible for making the enemy take damage and die. 
 */
public class EnemyHealth : MonoBehaviour {

	[SerializeField]
	private int health;

	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Dead();
	}

	private void Dead() {

	}

	public void TakeDamage(int attackDamage) {
		health -= attackDamage;
	}

	public int getEnemyHealth() {
		return health;
	}
}
