using UnityEngine;
using System.Collections;

public class NukeTimer : MonoBehaviour {
	float start;
	float alive = 3.8f;
	// Use this for initialization
	void Start () {
		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > start + alive)
			Destroy (gameObject);
	}
}
