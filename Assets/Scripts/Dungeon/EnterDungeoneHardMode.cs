using UnityEngine;
using System.Collections;

public class EnterDungeoneHardMode : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Application.LoadLevel(4);
	}
}
