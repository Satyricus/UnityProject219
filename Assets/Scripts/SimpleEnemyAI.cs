using UnityEngine;
using System.Collections;

/*
* This script is responsible for super simple AI, just placeholder AI.
*
*/

public class SimpleEnemyAI : MonoBehaviour
{


    private GameObject Player;
    private Rigidbody2D Body;
    public float Range;
    public float Speed;

	
	void Start () {
	Player = GameObject.FindGameObjectWithTag("Player");
	Body = GetComponent<Rigidbody2D>();

	}
	
	
	void Update ()
	{

	    float distance = Vector2.Distance(Body.position, Player.transform.position);

	    if (distance <= Range)
	    {
	        transform.Translate(Vector2.MoveTowards(Body.position, Player.transform.position, distance) * Speed * Time.deltaTime );
	    }

	}
}
