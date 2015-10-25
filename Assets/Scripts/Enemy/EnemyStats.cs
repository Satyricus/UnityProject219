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
		if (health <= 0)
			Die ();
	}



	public void Die() {
		if(debug)
			print ("dead");
		health = 0;
		anim.SetBool ("isDead", true);
		anim.SetBool ("isWalking", false);
	}

	// Called on last frame as an event. 
	void Terminate() {
		Destroy (gameObject);
	}


	public int GetAttackDamage() {
		return this.attackDamage;
	}

	public void TakeDamage(int damage) {
		if (debug)
			print ("Taking dmg. health = " + health);
		health -= damage;
	}

}
