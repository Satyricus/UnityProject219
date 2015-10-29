using UnityEngine;
using System.Collections;

public class MeleeAnimation : MonoBehaviour {

	private GameObject player;

	// time animation with appear.
	private float meleeAnimStart = Time.time;
	public float meleeAnimDuration = 2f; // 1 second
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
		if (Time.time > meleeAnimStart + meleeAnimDuration) {
			Destroy (gameObject);
		}
	}
}
