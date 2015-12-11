using UnityEngine;
using System.Collections;

public class weldscript : MonoBehaviour {
	GameObject player;
	float time;
	float cdTime;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		time = 0.0f;
		cdTime = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D coll){
		if(coll.gameObject.CompareTag("Player")){
			if(Time.time > time + cdTime){
				time = Time.time;
				player.GetComponent<PlayerStats>().Heal(1);
			}
		}
	}
}
