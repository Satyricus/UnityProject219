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

	private GameObject Status;
	private Text statusText;

	GameObject MovableChars;
	GamePause pause;

	// Use this for initialization
	void Start ()
	{
        Player = GameObject.Find("Player");
	    health = Player.GetComponentInChildren<Health>();
        healthText = GetComponentInChildren<Text>();
	    healthText.text = ""; 

		Status = GameObject.Find ("StatusText");
		statusText = Status.GetComponentInChildren<Text> ();
		statusText.enabled = false;

		MovableChars = GameObject.Find ("MovableCharacters");
		pause = MovableChars.GetComponent<GamePause> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    healthText.text = "health: " + health.getCurrentHealth();

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!pause.GetPausStatus()) {
				pause.Pause ();
				statusText.enabled = true;
				statusText.text = "status: Pause";
			}

			else {
				pause.UnPause();
				statusText.enabled = false;
			}
		}
	

	}
}
