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

    private GameObject _playerManager; // Just the game object which holds the reference of playerManager.
    private PlayerManager playerManager;
    private Text healthText;

	// Use this for initialization
	void Start ()
	{
	    _playerManager = GameObject.Find("_PlayerManager");
	    playerManager = _playerManager.GetComponentInChildren<PlayerManager>();
        healthText = GetComponentInChildren<Text>();
	    healthText.text = ""; 
	}
	
	// Update is called once per frame
	void Update ()
	{
	    healthText.text = "health: " + playerManager.playerHealth.ToString();

	}
}
