using System;
using UnityEngine;
using System.Collections;
using UnityEditor.Events;

public class Chest : MonoBehaviour
{

    private GameObject player;
    private BoxCollider2D playerCollider;
    private BoxCollider2D collider2D;
    private bool isOpen;
    public  string interactButton;
    public Sprite unopened;
    public Sprite opened;
    private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	    collider2D = GetComponent<BoxCollider2D>();
	    isOpen = false;
	    renderer = GetComponent<SpriteRenderer>();
	    renderer.sprite = unopened;
	}

	// Update is called once per frame
	void Update () {

    }
    
    // Triggers the 
    void OnTriggerStay2D(Collider2D other)
    {
        if (isOpen)   // If chest has been opened.
            return;
        // If player in range and interact button is pushed.
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(interactButton))
        {
            Open();
        }
    }

    /*
        Execute when chest is opened by player.
    */
    void Open()
    {
        print("it's open");
        isOpen = true;
        renderer.sprite = opened;
    }
}
