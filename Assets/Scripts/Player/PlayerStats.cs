using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	//Health playerHealth;
	Scaler statScaler;

	public float shieldReduction;		// Percent damage reduction when shiled is active.

	private int currentHealth;
	private bool iceShieldOn = false;	// Is ice shield active.

	private int level;	// Current level of the player.
	private int maxLevel;	// Max level the player can get to.
	private int currentExperience;	// Current amount of experience.
	private int neededExperience;	// Experience needed to level up.
	
	private int expForFirstLevel;	// Used to calculated neededExperience.
	private int expForLastLevel;	// Used to calculated neededExperience.

	[SerializeField]
	private float haste;			// Cooldown reduction stat.

	[SerializeField]
	private int attackDamage;		// Current damage increase.

	[SerializeField]
	private int maxHealth;		// The players maximum health.

	public bool debug;				// Use to debug.

	// Use this for initialization
	void Start () {
		//playerHealth = GetComponent<Health> ();
		statScaler = GameObject.Find ("StatScaler").GetComponent<Scaler>();
		currentHealth = maxHealth;

		level = 1;
		currentExperience = 0;
		attackDamage = 10;

		expForFirstLevel = 1000;
		expForLastLevel = 1000000;
		neededExperience = expForFirstLevel;
		maxLevel = 40;
		
		CalcNeededExperience (1);
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead())
			gameOver();
		if (currentExperience >= neededExperience) {
			LevelUp();
		}
	}

	/** Check whether the player is dead or not.  */
	bool isDead()
	{
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			return true;
		}
		
		return false;
	}
	
	/** A function called to increase the level of the player by 1. */
	void LevelUp() {
		level += 1;
		IncreaseStats ();
		statScaler.increaseLevel ();	// Increase the level on statscaler.
		currentExperience = neededExperience - currentExperience;	// Excess exp.
		CalcNeededExperience (level);
		PlayLevelUpAnimation ();
		if (debug) {
			print ("Leveled! Needed Exp: " + neededExperience + " attackDmg: " + attackDamage + " Health: " + maxHealth + " Haste: " + haste);
		}
	}

	/** Function called to play the animation when the player reaches a new level. */
	void PlayLevelUpAnimation() {
		// TODO: Implement this method.
		print ("YOU LEVELED UP CUPCAKE!!!");
	}

	/** A function used to calculate how much experience is needed this level to level up. */
	void CalcNeededExperience(int currentLevel) {
		float B = Mathf.Log ((float)expForLastLevel / (float)expForFirstLevel) / (maxLevel - 1);
		float A = (float)expForFirstLevel / (float)(Mathf.Exp (B) - 1.0f);
		int old_xp = (int)Mathf.Round(A * Mathf.Exp(B * (currentLevel - 1)));
		int new_xp = (int)Mathf.Round(A * Mathf.Exp(B * currentLevel));

		neededExperience = new_xp - old_xp;
	}

	/** A function used by gameobjects to increase the player's experience when the player does something which grants experience. */
	public void IncreaseCurrentExperience(int incAmount) {
		currentExperience += incAmount;
	}

	/** Called when the player gains a level to increase the player's stats. */
	void IncreaseStats() {
		// TODO: These are not the final increase values.
		maxHealth += 10;
		//playerHealth.ChangeMaxHealth (maxHealth);
		haste += 0.1f;
		attackDamage += 5;
	}

	/// <summary>
	/// Called by enemies to deal damage to our player. 
	/// </summary>
	/// <param name="damage"> Amount of damage the player will take.</param>
	public void TakeDamage(int damage) {
		int incDmg = damage;	// For calculating shield reduction.
		if (iceShieldOn) {			// Take 25% damage when ice shield is on.
			incDmg = (int) Mathf.Round ((float)(damage * shieldReduction));
			currentHealth -= incDmg;
		} else {
			currentHealth -= incDmg;
		}
	}
	/** Used once player is dead, can call a gameover scene. */
	void gameOver()
	{
		Application.LoadLevel(1);
	}

	/** This function is called when the player gets healed. */
	public void Heal(int amount) {
		currentHealth += amount;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}

	/** The shield prefab uses this to inform the player that the iceshield is active. */
	public void setShieldOn(bool isShieldOn) {
		iceShieldOn = isShieldOn;
	}

	// TODO: is this used? possible that all getLevel calls are done through statScaler.
    public int GetLevel()
    {
        return this.level;
    }
	/*
    // May not be the best way to do things, but now we don't really have to have a health reference in order to get access to current health. 
    public int GetCurrentHealth()
    {
        return playerHealth.getCurrentHealth();
    }
*/
    public int GetCurrentXP()
    {
        return currentExperience;
    }

    public int GetNeededXP()
    {
        return neededExperience;
    }

	public void SetIceShield(bool on) {
		iceShieldOn = on;
	}

	public int GetCurrentHealth() {
		return currentHealth;
	}

	/** Get and set player's haste. */
	public float Haste {
		get {return haste; }
		set {haste = value; }
	}

	/** Get and set player's attack damage. */
	public int AttackDamage {
		get {return attackDamage; }
		set {attackDamage = value; }
	}

	/** Get and set player's max health. */
	public int MaxHealth {
		get {return maxHealth; }
		set {maxHealth = value; }
	}
}