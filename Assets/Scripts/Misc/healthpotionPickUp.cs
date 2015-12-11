using UnityEngine;
using System.Collections;

public class healthpotionPickUp : MonoBehaviour {
	GameObject player;
	float time;
	float wait;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		time = Time.time;
		wait = 0.5f;
	}

	void OnCollisionStay2D(Collision2D coll){
		if(coll.gameObject.CompareTag("Player")){
				player.GetComponent<PlayerStats>().pickUpHealthPotions();
				Destroy(gameObject);
		}
	}


}
