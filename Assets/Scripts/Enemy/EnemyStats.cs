using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public int attackDamage;
	public int health;

	GameObject statScaler;
	Scaler level;
	public int damageIncrease;

	Animator anim;
	public bool debug;

	// Use this for initialization
	void Start () {
		statScaler = GameObject.Find ("StatScaler");
		anim = GetComponent<Animator> ();
		level = statScaler.GetComponent<Scaler> ();
		damageIncrease = level.GetScale ();

		attackDamage += damageIncrease;
		health += damageIncrease;

	}

	void Update() {
		if (health <= 0) {
			Die ();
		}
	}
	/**
	 * Return the health of the mob
	 */
	public int getHealth(){
		return this.health;
	}


	/** Kills the mob */
	public void Die() {
		if(debug)
			print ("dead");
		health = 0;
		anim.SetBool ("isDead", true);
		anim.SetBool ("isWalking", false);
	}

	/** Called on last frame as an event. Removes the gameobject*/
	void Terminate() {
		Destroy (gameObject);
	}

	/** Return attackdamage of the enemy */
	public int GetAttackDamage() {
		return this.attackDamage;
	}

	/**
	 * Take/remove damage/health from the enemy
	 * param damage: How much damage to take */
	public void TakeDamage(int damage) {
		if (debug)
			print ("Taking dmg. health = " + health);
		health -= damage;
	}

}
