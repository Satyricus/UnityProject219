using System;
using UnityEngine;
using System.Collections;

public class healthPickup : MonoBehaviour {
	public int health;
	GameObject player;
	Health h;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		h = player.GetComponent<Health> ();
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			if(h.getCurrentHealth() < h.getMaxHealth()){
				h.Heal(health);
				Destroy(gameObject);
			}

		}
	}
	                                         
}
