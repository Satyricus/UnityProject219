using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	Animator anim;
	Scaler statScaler;
	GameObject player;

	private int level;
	private int attackDamage;

	public int damageScaler;
	public int startDamage;	// How much damage this mob does at level 1
	public int health;
	public bool debug;
	public int yieldExp;	// How much experience this enemy yields.

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = GetComponent<Animator> ();
		statScaler = GameObject.Find ("StatScaler").GetComponent<Scaler> ();
		level = statScaler.GetScale ();
		attackDamage = DamageBasedOnLevel ();

		if (debug) {
			print (this.name + " does " + attackDamage + " damage.");
		}

		//health += damageIncrease;
		yieldExp = 100;	// TODO: This needs to be a dynamic number linked to scaler.

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
		player.GetComponent<PlayerStats>().IncreaseCurrentExperience(yieldExp);
		Destroy (gameObject);
	}

	/** How much damage this enemy should do based on the players level. */
	private int DamageBasedOnLevel() {
		print (startDamage + level * damageScaler);
		return startDamage + level * damageScaler;
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
			print ("Take damage: " + damage);
		health -= damage;
	}

}
