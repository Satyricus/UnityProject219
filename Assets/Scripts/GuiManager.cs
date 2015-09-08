using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
* This script is responsible for connecting the GUI elements with the game enements. 
*
* As of now it's only connecting the player with the GUI health on upper left corner. 
*/

public class GuiManager : MonoBehaviour
{

    private GameObject Player;
    private Health health;
    private Text healthText;

	// Use this for initialization
	void Start ()
	{
        Player = GameObject.Find("Player");
	    health = Player.GetComponentInChildren<Health>();
        healthText = GetComponentInChildren<Text>();
	    healthText.text = ""; 
	}
	
	// Update is called once per frame
	void Update ()
	{
	    healthText.text = "health: " + health.playerHealth.ToString();

	}
}
