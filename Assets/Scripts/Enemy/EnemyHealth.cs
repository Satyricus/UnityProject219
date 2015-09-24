using UnityEngine;
using System.Collections;

/**
 * This script is responsible for making the enemy take damage and die. 
 */
public class EnemyHealth : MonoBehaviour {

	[SerializeField]
	private int health;

	Animator anim;


	void Start() {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Dead();
	}

	private void Dead() {
		health = 0;
		anim.SetBool("isDead", true);
	}

	public void destroy() {
		Destroy(gameObject);
	}

	public void TakeDamage(int attackDamage) {
		health -= attackDamage;
	}

	public int getEnemyHealth() {
		return health;
	}
}
