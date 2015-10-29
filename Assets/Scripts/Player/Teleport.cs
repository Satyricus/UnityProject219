using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	private GameObject Player;
	private PlayerMovement PMovement;
	private Rigidbody2D rbody;
	Rigidbody2D tlpAnimation;
	Rigidbody2D tlpAnimation2;

	// Cooldown timer.
	private float tlpStart = -100f;		// Initial start value, so player can use spell instantly.
	public float tlpSpellCoolDown = 2f; // 2 seconds

	public Rigidbody2D prefab;
	public int tlpDistance;
	public string inputKey;
	public int step = 2;

	// Initialization
	void Start () {
		Player = GameObject.Find("Player");
		PMovement = Player.GetComponent<PlayerMovement>();
		rbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (inputKey) && Time.time > tlpStart + tlpSpellCoolDown) {
			tlpStart = Time.time;
			TeleportPlayer ();
		}
	}

	// Teleports player
	void TeleportPlayer() {
		if (PMovement.GetDirection ().x >= 1) {	// Teleport right
			// New position.
			Vector3 newPos = new Vector3(rbody.position.x + tlpDistance, rbody.position.y, 0);
			// Spawn teleport animation on current player location.
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
			// New player transform position.
			Player.transform.position = Vector3.MoveTowards(rbody.position, newPos, step);
			// Spawn teleport animation on new player location.
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
		else if (PMovement.GetDirection ().x < 0) {	// Teleport Left
			Vector3 newPos = new Vector3(rbody.position.x - tlpDistance, rbody.position.y, 0);
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
			Player.transform.position = Vector3.MoveTowards(rbody.position, newPos, step);
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
		else if (PMovement.GetDirection ().y >= 1) {	// Teleport Up
			Vector3 newPos = new Vector3(rbody.position.x, rbody.position.y + tlpDistance, 0);
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
			Player.transform.position = Vector3.MoveTowards(rbody.position, newPos, step);
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
		else if (PMovement.GetDirection ().y < 0) {	// Teleport Down
			Vector3 newPos = new Vector3(rbody.position.x, rbody.position.y - tlpDistance, 0);
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
			Player.transform.position = Vector3.MoveTowards(rbody.position, newPos, step);
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
	}
}
