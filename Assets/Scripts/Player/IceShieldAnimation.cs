using UnityEngine;
using System.Collections;

public class IceShieldAnimation : MonoBehaviour {

	private GameObject player;
	private Animator anim;

	private float shieldStart;
	public float shieldDuration = 7;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("shieldOn", true);
		shieldStart = Time.time;

		player = GameObject.Find("Player");
		player.GetComponent<PlayerStats> ().setShieldOn(true);	// Inform player object.
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > shieldStart + shieldDuration) {
			anim.SetBool("shieldOn", false);
			player.GetComponent<PlayerStats> ().setShieldOn(false);	// Inform player object.
		}
	}

	// Called on last frame as an event. 
	void Terminate() {
		Destroy (gameObject);
	}

	public float getDuration() {
		return shieldDuration;
	}
}
