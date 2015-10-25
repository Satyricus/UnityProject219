using UnityEngine;
using System.Collections;

public class IceShieldAnimation : MonoBehaviour {

	private GameObject player;
	private Animator anim;
	private bool shieldOn;

	private float shieldStart;
	public float shieldDuration = 7;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("shieldOn", true);
		shieldOn = true;		// To inform player object that shield is on.
		shieldStart = Time.time;

		player = GameObject.Find("Player");
		player.GetComponent<Health> ().setShieldOn (shieldOn);	// Inform player object.
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > shieldStart + shieldDuration) {
			anim.SetBool("shieldOn", false);
			shieldOn = false;
			player.GetComponent<Health> ().setShieldOn (shieldOn);	// Inform player object.
		}
	}

	// Called on last frame as an event. 
	void Terminate() {	// TODO Remove object from game without destroying animator.
		Destroy (gameObject);
	}

	public float getDuration() {
		return shieldDuration;
	}
}
