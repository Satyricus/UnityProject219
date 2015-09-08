    using System.CodeDom;
    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    using UnityEngine.UI;

    public class NPC : MonoBehaviour {

    public string[] dialog;
    public string inputKey;
    private Text UItext;
    private int counter;
    private bool hasTalked;


    // Use this for initialization
    void Start ()
    {
	    UItext = GetComponentInChildren<Text>();
	    UItext.text = "";
        hasTalked = false;
    }
	
    // Update is called once per frame
    void Update () {
	
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        print("entering " + hasTalked);
        counter = 0;
    }

    void OnTriggerLeave2D(Collider2D coll)
    {
        hasTalked = true;
        print("leaving " + hasTalked);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKeyDown((inputKey)))
        {
            if (hasTalked)
            {
                print("talked");
                UItext.text = "We have already talked";
            }
            else if(counter < dialog.Length)
            {
                UItext.text = dialog[counter++];
            }
            if (counter == dialog.Length+1)
            {
                UItext.text = "";
            }

        }
        
    }
}
