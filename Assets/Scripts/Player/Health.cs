using System;
using UnityEngine;
using System.Collections;

/*
* This script is responsible for keeping track of the players health, status (petrified, poisoned ... Etc), stats (level, strength ...) and abilities. 
*/
public class Health : MonoBehaviour
{
	public float shieldReduction;		// Percent damage reduction when shiled is active.

	private int maxHealth;
	private int currentHealth;
	private PlayerStats playerStats;
	private bool iceShieldOn = false;	// Is ice shield active.

    void Start()
    {
		playerStats = GetComponent<PlayerStats>();
		maxHealth = playerStats.MaxHealth;
		currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (isDead())
	        gameOver();
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
	/**
	 * Return the current health of the player*/
	public int getCurrentHealth() {
		return currentHealth;
	}
	/**
	 * Return the max health of the player*/
	public int getMaxHealth(){
		return maxHealth;
	}

	/** Primarily used when leveling up. Otherwise go through PlayerStats script. */
	public void ChangeMaxHealth(int newValue) {
		maxHealth = newValue;
		currentHealth = maxHealth;
	}
}
