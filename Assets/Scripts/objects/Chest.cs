using System;
using UnityEngine;
using System.Collections;
//using UnityEditor.Events;

public class Chest : MonoBehaviour
{

//    private GameObject player; // Will be used ones we transfer something from chest to player. 
	public GameObject prefab;
    private BoxCollider2D playerCollider;
    private bool isOpen;
    public  string interactButton;
    public Sprite unopened;
    public Sprite opened;
    private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
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
		if (other.gameObject.CompareTag("Player") && (Input.GetKeyDown(interactButton) || Input.GetKeyDown (KeyCode.Joystick1Button9)))
        {
            Open();
        }
    }

    /*
        Execute when chest is opened by player.
    */
    void Open()
    {
		GameObject h = Instantiate(prefab,transform.position/*new Vector2(transform.position.x,transform.position.y-0.03f)*/,Quaternion.identity) as GameObject;
        isOpen = true;
        renderer.sprite = opened;
    }

}
