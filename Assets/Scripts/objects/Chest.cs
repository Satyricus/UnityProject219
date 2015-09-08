using System;
using UnityEngine;
using System.Collections;
using UnityEditor.Events;

public class Chest : MonoBehaviour
{

    private GameObject player;
    private BoxCollider2D playerCollider;
    private BoxCollider2D collider2D;
    private Boolean isOpened;
    public  String interactButton;
    public Sprite unopened;
    public Sprite opened;
    private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	    collider2D = GetComponent<BoxCollider2D>();
	    isOpened = false;
	    renderer = GetComponent<SpriteRenderer>();
	    renderer.sprite = unopened;
	}
	


	// Update is called once per frame
	void Update () {

    }

    void OnCollisionStay2D()
    {
        //print("Collision :)");
    }
    // Triggers the 
    void OnTriggerStay2D(Collider2D other)
    {
        if (isOpened)
            return;
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(interactButton))
            {
                open();

            }
        }

    }

    void open()
    {
        print("it's open");
        isOpened = true;
        renderer.sprite = opened;
    }

    /*void OnTriggerEnter2D(Collider2D other)
        {
            print("Hello");     
        }*/

    }
