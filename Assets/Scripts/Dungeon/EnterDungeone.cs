using UnityEngine;
using System.Collections;

public class EnterDungeone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Application.LoadLevel(3);
	}
}
