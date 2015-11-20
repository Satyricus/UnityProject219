using UnityEngine;
using System.Collections;

public class RangeAttack : MonoBehaviour {

	public int force;

	public string attackKey;
	public Rigidbody2D prefab;

	private float fireBallStart = 0f;
	public float fireBallCooldown = 0.5f;	// 0.5 seconds

	private PlayerMovement PMovement;

	void Start() {
		PMovement = GetComponent<PlayerMovement>();

	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (attackKey) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && Time.time > fireBallStart + fireBallCooldown) {
			fireBallStart = Time.time;
			SpawnAttack ();
		}
	}
	/**
	 * Spawn a fireball from player in the direction the player is facing */
	void SpawnAttack() {
		//Vector2 targetDirection = 
		Rigidbody2D fireball = Instantiate(prefab, transform.position, Quaternion.identity) as Rigidbody2D;
		fireball.AddForce(transform.forward * force);
	}

    // True if fireball is currently on cooldown. 
    public bool GetFireBallCooldownStatus()
    {
        return (Time.time < fireBallStart + fireBallCooldown);
    }

}
