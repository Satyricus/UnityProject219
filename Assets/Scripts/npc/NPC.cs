    using System.CodeDom;
    using UnityEngine;
    using System.Collections;
    //using UnityEditor;
    using UnityEngine.UI;

    public class NPC : MonoBehaviour {

    public string[] dialogOne;  
	public string[] dialogTwo; // Something the character says after the important part. "We've already talked", "Didn't I tell you to kill x of y... " etc. 
    public string inputKey;
	private string[] currentDialog; 


	private GameObject GameGui;
	private GameObject Dialog;
    private Text UItext;

    private int current;
	private int lastLine;
    private bool hasTalked;
	private bool isTalking;

	private GameObject Player;

	GameObject MovableChars;
	GamePause pause;

    // Use this for initialization
    void Start ()
    {
		MovableChars = GameObject.Find ("MovableCharacters");
		pause = MovableChars.GetComponent<GamePause> ();


		GameGui = GameObject.Find ("GameGui");
		Dialog = GameObject.Find ("Dialog");
		UItext = Dialog.GetComponentInChildren<Text> ();
		Player = GameObject.FindGameObjectWithTag ("Player");

		Dialog.SetActive (false);
		currentDialog = dialogOne;

        hasTalked = false;
		current = 0;
		lastLine = dialogOne.Length;
	    }
	
    // Update is called once per frame
    void Update () {
		if (current == lastLine + 1) {
			Dialog.SetActive(false);
			HasTalked();
		}

    } 

	void HasTalked() {
		hasTalked = true;
		currentDialog = dialogTwo;
		lastLine = currentDialog.Length;
		current = 0;
		pause.UnlockCharacters();
	}


	void Talk() {
		pause.LockCharacters();	

		if(current < currentDialog.Length)
		{
			Dialog.SetActive(true);
			UItext.text = currentDialog[current];
		}
		current++;
	}

    void OnTriggerStay2D(Collider2D coll) {
		if (Input.GetKeyDown((inputKey))) {
			Talk ();
	}

		//Dialog.SetActive (false);        
    }
}
