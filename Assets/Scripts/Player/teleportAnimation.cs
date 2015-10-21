using UnityEngine;
using System.Collections;

public class teleportAnimation : MonoBehaviour {

	// time animation with appear.
	private float tlpAnimStart = Time.time;
	public float tlpAnimLastTime = 1f; // 1 second

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > tlpAnimStart + tlpAnimLastTime) {
			Destroy (gameObject);
		}
	}
}
