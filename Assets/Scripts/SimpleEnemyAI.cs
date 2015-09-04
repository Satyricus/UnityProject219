using UnityEngine;
using System.Collections;

/*
* This script is responsible for super simple AI, just placeholder AI.
*
*/

public class SimpleEnemyAI : MonoBehaviour
{
	
    GameObject player;
    //Rigidbody2D body;
    float range;
	Transform target;

    public float speed;
	public float aggroRadius;

	void Start () 
	{

		player = GameObject.FindGameObjectWithTag("Player");
		//body = GetComponent<Rigidbody2D>();

	}
	
	
	void Update ()
	{
		/*
	    float distance = Vector2.Distance(transform.position, player.transform.position);

		// TODO: if (playerHealth >= 0)

		//transform.position += transform.forward * speed * Time.deltaTime;


	    if (distance >= 15f)
	    {
			//body.MovePosition (player.transform.position * Time.deltaTime * speed);
	        transform.Translate(Vector2.MoveTowards(transform.position, player.transform.position, distance) * speed * Time.deltaTime );
	    }
		*/
	}

	// Called once per frame.
	void FixedUpdate() {

		target = player.transform;

		// Temp, for debugging.
		Debug.DrawLine (transform.position, target.position, Color.yellow);

		range = Vector3.Distance (transform.position, target.position);

		if (range <= .5f) {	// Stop moving and attack.
			transform.position = transform.position;
			Attack ();	// TODO: implement attack.
		} else if (range < aggroRadius) {	// If player is in (aggro) range, move towards player.
			Vector3 targetDirection = target.position - transform.position;
			transform.position += targetDirection * speed * Time.deltaTime;
		}
	}

	void Attack() {

	}
}
