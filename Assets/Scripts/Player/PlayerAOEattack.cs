using UnityEngine;
using System.Collections;

public class PlayerAOEattack : MonoBehaviour {
	public string attackKey;
	public float radius;
	public int attackDamage;
	private float AOEstart = -50f;
	public float coolDown = 60f;
	public Rigidbody2D prefab;
	private Rigidbody2D nuke;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawLine(transform.position,new Vector2(transform.position.x + radius, transform.position.y));
		if ((Input.GetKeyDown(attackKey) || Input.GetKeyDown(KeyCode.Joystick1Button3)) && Time.time > AOEstart + coolDown) {
			AOEstart = Time.time;
			nuke = Instantiate(prefab,new Vector2(transform.position.x+1,transform.position.y),Quaternion.identity) as Rigidbody2D;
			nuke = Instantiate(prefab,new Vector2(transform.position.x-1,transform.position.y),Quaternion.identity) as Rigidbody2D;
			nuke = Instantiate(prefab,new Vector2(transform.position.x,transform.position.y+1),Quaternion.identity) as Rigidbody2D;
			nuke = Instantiate(prefab,new Vector2(transform.position.x,transform.position.y-1),Quaternion.identity) as Rigidbody2D;
			nuke = Instantiate(prefab,new Vector2(transform.position.x+1,transform.position.y+1),Quaternion.identity) as Rigidbody2D;
			nuke = Instantiate(prefab,new Vector2(transform.position.x-1,transform.position.y-1),Quaternion.identity) as Rigidbody2D;
			nuke = Instantiate(prefab,new Vector2(transform.position.x-1,transform.position.y+1),Quaternion.identity) as Rigidbody2D;
			nuke = Instantiate(prefab,new Vector2(transform.position.x+1,transform.position.y-1),Quaternion.identity) as Rigidbody2D;
			Collider2D [] enemies = Physics2D.OverlapCircleAll(transform.position,radius);	
			foreach (Collider2D enem in enemies) {
				if (enem.CompareTag ("Enemy")) {
					EnemyStats eStats = enem.GetComponent<EnemyStats> ();
					eStats.TakeDamage (attackDamage);
				}
			}
		}
	}

    public bool isNukeOnCooldown()
    {
        return (Time.time < AOEstart + coolDown);
    }
}
