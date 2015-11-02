using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	
	private int level;	// Current level of the player.
	private int maxLevel;	// Max level the player can get to.
	private int currentExperience;	// Current amount of experience.
	private int neededExperience;	// Experience needed to level up.
	
	private int expForFirstLevel;	// Used to calculated neededExperience.
	private int expForLastLevel;	// Used to calculated neededExperience.

	[SerializeField]
	private float haste { get; set; }			// Cooldown reduction stat.
	[SerializeField]
	private int attackDamage { get; set; }		// Current damage increase.
	[SerializeField]
	private int maxHealth { get; set; }			// The players maximum health.

	// Use this for initialization
	void Start () {
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

	void IncreaseStats() {
		// TODO: These are not the final increases values.
		haste += 0.1;
		attackDamage += 1;
	}
}