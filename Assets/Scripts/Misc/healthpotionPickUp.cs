using UnityEngine;
using System.Collections;

public class healthpotionPickUp : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.CompareTag("Player")){
			float time = Time.time;
			player.GetComponent<PlayerStats>().pickUpHealthPotions();
			Destroy(gameObject);
		}
	}

}
