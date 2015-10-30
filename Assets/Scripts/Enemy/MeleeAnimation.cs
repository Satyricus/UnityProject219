using UnityEngine;
using System.Collections;

public class MeleeAnimation : MonoBehaviour {

	private GameObject player;

	// time animation with appear.
	private float meleeAnimStart;
	public float meleeAnimDuration;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		meleeAnimStart = Time.time;
		meleeAnimDuration = 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
		if (Time.time > meleeAnimStart + meleeAnimDuration) {
			Destroy (gameObject);
		}
	}
}
