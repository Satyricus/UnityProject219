using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	Animator anim;
	Scaler statScaler;
	GameObject player;

	private int level;
	private int attackDamage;

	public int damageScaler;	// Scale damage by this amount.
	public int startDamage;	// How much damage this mob does at level 1
	public int health;
	public bool debug;
	public int yieldExp;	// How much experience this enemy yields.
	public int healthIncrease;	// How much health this mob gets per level.

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = GetComponent<Animator> ();
		statScaler = GameObject.Find ("StatScaler").GetComponent<Scaler> ();
		level = statScaler.GetScale ();
		attackDamage = startDamage + level * damageScaler;
		health = health + (level-1) * healthIncrease;
		yieldExp = 100 + (level-1) * 5;
		if (debug)
			print (this.name + " gets a scaler of " + statScaler.GetScale ());
		if (debug)
			print (this.name + " does " + attackDamage + " damage and has " + health + " health and gives " + yieldExp + " experience");

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
