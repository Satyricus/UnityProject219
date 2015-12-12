using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEditor;

public class PotionsGui : MonoBehaviour {


	private Text potionText;

	GameObject player;
	PlayerStats pstats;

	// Use this for initialization
	void Start () {
		potionText = GetComponentInChildren<Text>();

		player = GameObject.Find ("Player");
		pstats = player.GetComponent<PlayerStats>();


	}
	
	// Update is called once per frame
	void Update () {
		potionText.text = "Potions: " + pstats.getHealthPotions();
	}
}
