using UnityEngine;
using System.Collections;

public class Objectives : MonoBehaviour
{

    GameObject trashMobHolder;
    private int amountOfTrashMobs;
    CavernManager cavMan;

    GameObject CavernManager;

	// Use this for initialization
	void Start () {
	    trashMobHolder = GameObject.Find("TrashMobHolder");
	    amountOfTrashMobs = trashMobHolder.transform.childCount;
     
	}
	
	// Update is called once per frame
	void Update ()
	{
        
           
	}

    private bool AllTrashMobsAreDead()
    {
        return (amountOfTrashMobs == 0);            
    }
}
