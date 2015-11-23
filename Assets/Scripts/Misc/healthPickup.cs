using System;
using UnityEngine;
using System.Collections;

public class healthPickup : MonoBehaviour {
	public int health;
	GameObject player;
	PlayerStats h;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		h = player.GetComponent<PlayerStats> ();
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			if(h.GetCurrentHealth() < h.MaxHealth){
				h.Heal(health);
				Destroy(gameObject);
			}

		}
	}
	                                         
}
