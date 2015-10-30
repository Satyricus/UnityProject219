using UnityEngine;
using System.Collections;

public class teleportAnimation : MonoBehaviour {

	// time animation with appear.
	private float tlpAnimStart;
	public float tlpAnimDuration;

	// Use this for initialization
	void Start () {
		tlpAnimStart = Time.time;
		tlpAnimDuration = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > tlpAnimStart + tlpAnimDuration) {
			Destroy (gameObject);
		}
	}
}
