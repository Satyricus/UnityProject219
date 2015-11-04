using UnityEngine;
using System.Collections;

public class Objectives : MonoBehaviour
{

    GameObject trashMobHolder;
    private int amountOfTrashMobs;

	// Use this for initialization
	void Start () {
	    trashMobHolder = GameObject.Find("TrashMobHolder");
	    amountOfTrashMobs = trashMobHolder.transform.childCount;
	}
	
	// Update is called once per frame
	void Update ()
	{
        // Upodate the number of trashmobs alive. 
	    if (amountOfTrashMobs < trashMobHolder.transform.childCount)
	        amountOfTrashMobs = trashMobHolder.transform.childCount;
        /*
        if (AllTrashMobsAreDead())
            // TODO SpawnBoss.*/
	}

    private bool AllTrashMobsAreDead()
    {
        if (amountOfTrashMobs == 0)
            return true;
        return false;
    }
}
