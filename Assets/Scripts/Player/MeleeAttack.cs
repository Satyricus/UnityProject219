using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	public Rigidbody2D rb;
	public string inputKey;

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown(inputKey))
			Attack(other);
	}

	void Attack(Collider2D other) {
		
	}
}
