using UnityEngine;
using System.Collections;

public class RangeAttack : MonoBehaviour {

	public int force;

	public string attackKey;
	public Rigidbody2D prefab;

	private GameObject Player;
	private PlayerMovement PMovement;

	void Start() {
		Player = GameObject.Find("Player");
		PMovement = Player.GetComponent<PlayerMovement>();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(attackKey))
			SpawnAttack();
	}
	
	void SpawnAttack() {
		Rigidbody2D fireball = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		fireball.AddForce(PMovement.GetDirection() * force);
	}

}
