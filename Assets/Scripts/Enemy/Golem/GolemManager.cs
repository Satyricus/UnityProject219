using System;
using UnityEngine;
using System.Collections;

public class GolemManager : MonoBehaviour
{

    enum Direction
    {
        North,
        West,
        South,
        East
    };

    enum State
    {
        Idle,
        LostTarget,
        HasTarget,
        Attack
    };

    // Starter position, will go back here if loses sight of player. 
    private Vector3 starterPosition;

    private Rigidbody2D body;
    private GameObject target;
    private BoxCollider2D bodyCollider;


    private Direction lookingDirection;
    private State currentState;

    private GameObject VisionWrapper;
    private GolemVision vision;
    private BoxCollider2D visionCollider;





	// Use this for initialization
	void Start ()
	{

	    body = GetComponent<Rigidbody2D>();
	    starterPosition = body.transform.position;
	    target = null;
	    bodyCollider = GetComponent<BoxCollider2D>();

        currentState = State.Attack;

        lookingDirection = Direction.South;
	    
        VisionWrapper = GameObject.Find("Vision");
	    vision = VisionWrapper.GetComponent<GolemVision>();
	    visionCollider = VisionWrapper.GetComponent<BoxCollider2D>();


	}
	
	// Update is called once per frame
	void Update ()
	{
	    target = vision.GetTarget();

	}

    private void ChangeState()
    {
        if (currentState == State.Idle && target == null)
            return;

        if (currentState == State.HasTarget && target == null)
            LostTarget();

        if (currentState == State.HasTarget && target != null)
            Attack();

    }

    private void LostTarget()
    {
        currentState = State.LostTarget;
        LookAround();
    }

    private void LookAround()
    {
        
    }

    private void Attack()
    {
        
    }


}
