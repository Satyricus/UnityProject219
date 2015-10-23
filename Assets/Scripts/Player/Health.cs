using System;
using UnityEngine;
using System.Collections;

/*
* This script is responsible for keeping track of the players health, status (petrified, poisoned ... Etc), stats (level, strength ...) and abilities. 
*/
public class Health : MonoBehaviour
{

    public int playerHealth;

    void start()
    {
        playerHealth = 100;
        print((playerHealth));
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (isDead())
	        gameOver();
	}

    // Check whether the player is dead or not. 
    Boolean isDead()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            return true;
        }

        return false;
    }

	public void TakeDamage(int damage) {
		playerHealth -= damage;
	}

    // Used once player is dead, can call a gameover scene. 
    void gameOver()
    {
        Application.LoadLevel(1);
    }
}
