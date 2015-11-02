using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	Health playerHealth;

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

	// Use this for initialization
	void Start () {
		playerHealth = GetComponent<Health> ();

		level = 1;
		currentExperience = 0;

		expForFirstLevel = 1000;
		expForLastLevel = 1000000;
		neededExperience = expForFirstLevel;
		maxLevel = 40;
		
		CalcNeededExperience (1);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentExperience >= neededExperience) {
			LevelUp();
		}
	}
	
	/** A function called to increase the level of the player by 1. */
	void LevelUp() {
		level += 1;
		IncreaseStats ();
		CalcNeededExperience (level);
		PlayLevelUpAnimation ();
	}

	/** Function called to play the animation when the player reaches a new level. */
	void PlayLevelUpAnimation() {
		// TODO: Implement this method.
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
	void IncreaseCurrentExperience(int incAmount) {
		currentExperience += incAmount;
	}

	/** Called when the player gains a level to increase the player's stats. */
	void IncreaseStats() {
		// TODO: These are not the final increase values.
		maxHealth += 20;
		playerHealth.ChangeMaxHealth (maxHealth);
		haste += 0.1f;
		attackDamage += 1;
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