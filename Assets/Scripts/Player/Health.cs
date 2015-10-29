using System;
using UnityEngine;
using System.Collections;

/*
* This script is responsible for keeping track of the players health, status (petrified, poisoned ... Etc), stats (level, strength ...) and abilities. 
*/
public class Health : MonoBehaviour
{

    public int playerHealth;
	public float shieldReduction;		// Percent damage reduction when shiled is active.

	private bool iceShieldOn = false;	// Is ice shield active.

    void start()
    {
        playerHealth = 100;
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
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            return true;
        }

        return false;
    }

	/** Called by enemies to deal damage to our player. */
	public void TakeDamage(int damage) {
		int incDmg = damage;
		if (iceShieldOn) {			// Take 25% damage when ice shield is on.
			incDmg = (int) Mathf.Round ((float)(damage * shieldReduction));
			playerHealth -= incDmg;
		} else {
			playerHealth -= incDmg;
		}
	}

    /** Used once player is dead, can call a gameover scene. */
    void gameOver()
    {
        Application.LoadLevel(1);
    }

	/** The shield prefab uses this to inform the player that the iceshield is active. */
	public void setShieldOn(bool isShieldOn) {
		iceShieldOn = isShieldOn;
	}
}
