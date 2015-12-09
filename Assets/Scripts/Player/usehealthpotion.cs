using UnityEngine;
using System.Collections;

public class usehealthpotion : MonoBehaviour {
	public string useKey;
	private PlayerStats playerstats;
	// Use this for initialization
	void Start () {
		playerstats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (useKey) || Input.GetKeyDown (KeyCode.Joystick1Button5))) 
			if(playerstats.getHealthPotions() > 0 && playerstats.GetCurrentHealth() < playerstats.getMaxHealth()){
				playerstats.useHealthPotion();
		}
	}
}
