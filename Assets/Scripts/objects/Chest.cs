using System;
using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
	public GameObject prefab;
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
    void OnTriggerStay2D(Collider2D other){
        if (isOpen)   // If chest has been opened.
            return;
        // If player in range and interact button is pushed.
		else if (other.gameObject.CompareTag("Player") && (Input.GetKeyDown(interactButton) || Input.GetKeyDown (KeyCode.Joystick1Button9)))
        {
			GameObject h = Instantiate(prefab,transform.position,Quaternion.identity) as GameObject; // Spawn a healthpotion
			isOpen = true;
			renderer.sprite = opened;
        }
    }
}
