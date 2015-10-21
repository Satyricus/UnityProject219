using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	GameObject Player;
	PlayerMovement PMovement;
	Rigidbody2D RB;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		PMovement = Player.GetComponent<PlayerMovement> ();
		RB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void GetRelativeLocation() {
		Vector2 Pdirection = PMovement.GetDirection();

		RB.position = RB.position + Pdirection;
	}
}

