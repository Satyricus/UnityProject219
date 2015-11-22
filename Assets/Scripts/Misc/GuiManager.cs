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

    private GameObject player;
    private Text healthText;


	GameObject MovableChars;
	GamePause pause;

	// Use this for initialization
	void Start ()
	{
        player = GameObject.Find("Player");
        healthText = GetComponentInChildren<Text>();
	    healthText.text = ""; 
		MovableChars = GameObject.Find ("MovableCharacters");
		pause = MovableChars.GetComponent<GamePause> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthText.text = "health: " + player.GetComponent<PlayerStats> ().GetCurrentHealth ();
	}
}
