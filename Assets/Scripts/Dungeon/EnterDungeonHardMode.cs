using UnityEngine;
using System.Collections;

public class EnterDungeonHardMode : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Application.LoadLevel (4);
		}
	}
}
