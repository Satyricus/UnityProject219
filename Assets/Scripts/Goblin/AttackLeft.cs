using UnityEngine;
using System.Collections;

public class AttackLeft : MonoBehaviour
{

    private BoxCollider2D coll;
    private Animator animator;
    public int attackDamage;

	// Use this for initialization
	void Start ()
	{
        coll = GetComponent<BoxCollider2D>();
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("attacking", true);
            //Play attack animation
            //Decrease player Health
            //

        animator.Play("AttackLeft");

        }     
    }
}
