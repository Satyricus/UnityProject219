using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;	// position of target
	public float speed = 0.03f;
	Camera cam;

	// Use this for initialization
	void Start () {
	
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		cam.orthographicSize = (Screen.height / 100f) / 2f; // Adjust screen by resolution

		if (target) {
			transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0, 0, -10);	// Linear interpelate, add -10 so camera stays put on z axis.
		}
	}
}
