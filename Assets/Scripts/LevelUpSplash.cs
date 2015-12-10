using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpSplash : MonoBehaviour {

	private int currentLevel;
	GameObject player;
	PlayerStats pStats;

	[SerializeField]
	private float levelUpSplashScreenUptime;
	private float SplashScreenStartTime;
	private Text levelUpText; 


	// Use this for initialization
	void Start () {
		currentLevel = 1;
		player = GameObject.Find ("Player");
		pStats = player.GetComponent<PlayerStats>();
		levelUpText = GetComponentInChildren<Text>();
		
		HideSplashScreen();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentLevel < pStats.GetLevel()) {
			currentLevel = pStats.GetLevel();
			ShowSplashScreen();
		}

		if (Time.time >= SplashScreenStartTime + levelUpSplashScreenUptime)
			HideSplashScreen();
	}

	private void ShowSplashScreen() {
		levelUpText.enabled = true;
		levelUpText.text = "You leveled up to level: " + currentLevel;
		SplashScreenStartTime = Time.time;
	}
	
	private void HideSplashScreen() {
		levelUpText.enabled = false;
	}
}
