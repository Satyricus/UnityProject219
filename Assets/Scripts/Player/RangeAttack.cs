using UnityEngine;
using System.Collections;

public class RangeAttack : MonoBehaviour {

	public int force;

	public string attackKey;
	public Rigidbody2D prefab;

	private float fireBallStart = 0f;
	public float fireBallCooldown = 0.5f;	// 0.5 seconds

	private GameObject Player;
	private PlayerMovement PMovement;

	void Start() {
		Player = GameObject.Find("Player");
		PMovement = Player.GetComponent<PlayerMovement>();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (attackKey) && Time.time > fireBallStart + fireBallCooldown) {
			fireBallStart = Time.time;
			SpawnAttack ();
		}
	}
	
	void SpawnAttack() {
		Rigidbody2D fireball = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		fireball.AddForce(PMovement.GetDirection() * force);
	}

}
