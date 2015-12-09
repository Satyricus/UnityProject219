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
		if ((Input.GetKeyDown (inputKey) || Input.GetKeyDown(KeyCode.Joystick1Button2)) && Time.time > tlpStart + tlpSpellCoolDown) {
			tlpStart = Time.time;
			TeleportPlayer ();
		}
	}

	// Teleports player
	void TeleportPlayer() {
		if (PMovement.GetDirection ().x >= 1) {	// Teleport right
			// New position.
			Vector2 newPos = new Vector2(rbody.position.x + tlpDistance, rbody.position.y);
			// Player position plus some delta to avoid players own 2d box collider.
			Vector2 playerPos = new Vector2(Player.transform.position.x+0.2f, Player.transform.position.y);
			// Raycast detects collisions between two points.
			RaycastHit2D hitDetec = Physics2D.Linecast (playerPos, newPos);
			// Spawn teleport animation on current player location.
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;

			// New player transform position.
			if (hitDetec.collider == null) {	// No collision, teleport max distance.
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			} else {	// Collision, teleport to collision point.
				newPos = new Vector2 (hitDetec.point.x-0.2f, hitDetec.point.y);
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			}

			// Spawn teleport animation on new player location.
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
		else if (PMovement.GetDirection ().x < 0) {	// Teleport Left
			Vector2 newPos = new Vector2(rbody.position.x - tlpDistance, rbody.position.y);
			Vector2 playerPos = new Vector2(Player.transform.position.x-0.2f, Player.transform.position.y);
			RaycastHit2D hitDetec = Physics2D.Linecast (playerPos, newPos);
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
			if (hitDetec.collider == null) {
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			} else {	// Collision, teleport to collision point.
				newPos = new Vector2 (hitDetec.point.x+0.2f, hitDetec.point.y);
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			}
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
		else if (PMovement.GetDirection ().y >= 1) {	// Teleport Up
			Vector2 newPos = new Vector2(rbody.position.x, rbody.position.y + tlpDistance);
			Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y+0.2f);
			RaycastHit2D hitDetec = Physics2D.Linecast (playerPos, newPos);
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
			if (hitDetec.collider == null) {
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			} else {	// Collision, teleport to collision point.
				newPos = new Vector2 (hitDetec.point.x, hitDetec.point.y-0.2f);
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			}
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
		else if (PMovement.GetDirection ().y < 0) {	// Teleport Down
			Vector2 newPos = new Vector2(rbody.position.x, rbody.position.y - tlpDistance);
			Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y-0.2f);
			RaycastHit2D hitDetec = Physics2D.Linecast (playerPos, newPos);
			tlpAnimation = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
			if (hitDetec.collider == null) {
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			} else {	// Collision, teleport to collision point.
				newPos = new Vector2 (hitDetec.point.x, hitDetec.point.y+0.2f);
				Player.transform.position = Vector2.MoveTowards(rbody.position, newPos, step);
			}
			tlpAnimation2 = Instantiate(prefab, Player.transform.position, Quaternion.identity) as Rigidbody2D;
		}
	}

    public bool GetTeleportCooldownStatus()
    {
        return (Time.time < tlpStart + tlpSpellCoolDown);
    }
}
