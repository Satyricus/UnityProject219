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



	private Transform npcTransform;
	private GameObject GameGui;
	private GameObject Dialog;
    private Text UItext;
	private Image panel;

    private int current;
	private int lastLine;
    private bool hasTalked;
	private bool isTalking;

	private GameObject Player;


	SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite up;

	[SerializeField]
	private Sprite down;

	[SerializeField]
	private Sprite left;

	[SerializeField]
	private Sprite right;

    // Use this for initialization
    void Start ()
	{
		GameGui = GameObject.Find ("GameGui");
		Dialog = GameObject.Find ("Dialog");
		UItext = Dialog.GetComponentInChildren<Text> ();
		panel = Dialog.GetComponentInChildren<Image>();
		Player = GameObject.Find ("Player");
		npcTransform = GetComponent<Transform>();
		spriteRenderer = GetComponent<SpriteRenderer>();


		spriteRenderer.sprite = down;

		removeDialog ();
		currentDialog = dialogOne;

        hasTalked = false;
		current = 0;
		lastLine = dialogOne.Length;
	    }
	
    // Update is called once per frame
    void Update () {
		if (current == lastLine + 1) {
			removeDialog();
			HasTalked();
		}

    } 

	void HasTalked() {
		hasTalked = true;
		currentDialog = dialogTwo;
		lastLine = currentDialog.Length;
		current = 0;
	}

	private void removeDialog() {
		UItext.enabled = false;
		panel.enabled = false;
	}

	private void showDialog() {
		UItext.enabled = true;
		panel.enabled = true;
	}

	void Talk() {
		if(current < currentDialog.Length)
		{
			showDialog();
			UItext.text = currentDialog[current];
		}
		current++;
	}

    void OnTriggerStay2D(Collider2D coll) {
		if (Input.GetKeyDown((inputKey))|| Input.GetKeyDown (KeyCode.Joystick1Button9)) {
			ChangeLookingDirection();
			Talk ();
	}

    }

	private void ChangeLookingDirection() {
		var playerPosition = Player.transform.position;
		var npcPosition = npcTransform.transform.position;
		float xDifference = Mathf.Abs( npcPosition.x - playerPosition.x);
		float yDifference = Mathf.Abs( npcPosition.y - playerPosition.y);



		if (npcPosition.x > playerPosition.x && xDifference > yDifference) {
			spriteRenderer.sprite = left;
		}
		
		if (npcPosition.x < playerPosition.x && xDifference > yDifference) {
			spriteRenderer.sprite = right;
		}

		if (npcPosition.y > playerPosition.y && yDifference > xDifference) {
			spriteRenderer.sprite = down;
		}

		if (npcPosition.y < playerPosition.y && yDifference > xDifference) {
			spriteRenderer.sprite = up;
		}

	}

	void OnTriggerExit2D(Collider2D coll) {
		current = 0;
		removeDialog();
	}
}
