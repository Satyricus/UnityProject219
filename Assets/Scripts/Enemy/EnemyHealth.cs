using UnityEngine;
using System.Collections;

/**
 * This script is responsible for making the enemy take damage and die. 
 */
public class EnemyHealth : MonoBehaviour {

	[SerializeField]
	private int health;
	SimpleEnemyAI ai;
	Animator anim;


	void Start() {
		anim = GetComponent<Animator>();
		ai = GetComponent<SimpleEnemyAI>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Dead();
	}

	private void Dead() {
		health = 0;
		ai.LockGoblin();
		anim.SetBool("isWalking", false);
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
