using System;
using UnityEngine;
using System.Collections;
using UnityEditor.Events;

public class Chest : MonoBehaviour
{

//    private GameObject player; // Will be used ones we transfer something from chest to player. 
    private BoxCollider2D playerCollider;
    private bool isOpen;
    public  string interactButton;
    public Sprite unopened;
    public Sprite opened;
    private SpriteRenderer renderer;
	private Item containedItem;

	// Use this for initialization
	void Start () {
//        player = GameObject.FindWithTag("Player");
	    isOpen = false;
	    renderer = GetComponent<SpriteRenderer>();
	    renderer.sprite = unopened;
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
