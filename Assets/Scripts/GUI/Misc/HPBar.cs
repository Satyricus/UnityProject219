using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {


	GameObject Player;
	PlayerStats PStats;
	
	[SerializeField]
	private Image Bar;


	void Start() {
		Player = GameObject.Find ("Player");

		PStats = Player.GetComponent<PlayerStats>();


	}

	// Update is called once per frame
	void Update () {
		if (Player == null) {
			Player = GameObject.Find ("Player");
			PStats = Player.GetComponent<PlayerStats>();
		}

		UpdateHPBar();


	}

	private void UpdateHPBar() {
		int maxHP = PStats.getMaxHealth();
		int currentHP = PStats.GetCurrentHealth();
		float fill =  currentHP/maxHP;

		Bar.fillAmount = fill;
		print (fill);
	}
}
